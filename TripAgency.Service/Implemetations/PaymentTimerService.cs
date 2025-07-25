﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using TripAgency.Service.Abstracts;

namespace TripAgency.Service.Implementations
{
    public class PaymentTimerService : IPaymentTimerService, IDisposable
    {
        private readonly ILogger<PaymentTimerService> _logger;
        // ConcurrentDictionary آمن للاستخدام من خيوط متعددة
        private static readonly ConcurrentDictionary<int, CancellationTokenSource> _activeTimers = new ConcurrentDictionary<int, CancellationTokenSource>();
        private readonly IServiceScopeFactory _scopeFactory; // لإنشاء Scope جديد داخل الـ Task

        public PaymentTimerService(ILogger<PaymentTimerService> logger, IServiceScopeFactory scopeFactory)
        {
            _logger = logger;
            _scopeFactory = scopeFactory;
        }

        public void StartPaymentTimer(int bookingId, TimeSpan timeoutDuration)
        {
            var cts = new CancellationTokenSource(); // مصدر إلغاء للمؤقت
            _activeTimers[bookingId] = cts; // بنخزن الـ CancellationTokenSource عشان نقدر نوقف المؤقت

            _logger.LogInformation("بدء مؤقت دفع للحجز {BookingId} لمدة {Minutes} دقائق.", bookingId, timeoutDuration.TotalMinutes);

            // تشغيل مهمة في الخلفية (Task)
            Task.Run(async () =>
            {
                try
                {
                    await Task.Delay(timeoutDuration, cts.Token); // انتظار انتهاء المهلة أو الإلغاء
                    if (!cts.Token.IsCancellationRequested) // إذا لم يتم إلغاء المؤقت يدوياً
                    {
                        _logger.LogWarning("المؤقت للحجز {BookingId} انتهت صلاحيته.", bookingId);
                        // نطلب من BookingService معالجة انتهاء المهلة
                        using (var scope = _scopeFactory.CreateScope()) // إنشاء Scope جديد لأننا خارج طلب HTTP
                        {
                            var paymentService = scope.ServiceProvider.GetRequiredService<IPaymentService>();
                            await paymentService.HandlePaymentTimeoutAsync(bookingId);
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    _logger.LogInformation("المؤقت للحجز {BookingId} تم إيقافه يدوياً.", bookingId);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "خطأ في خدمة المؤقت للحجز {BookingId}.", bookingId);
                }
                finally
                {
                    _activeTimers.TryRemove(bookingId, out _); // إزالة المؤقت من القائمة بعد انتهائه/إيقافه
                    cts.Dispose(); // التخلص من الـ CancellationTokenSource
                }
            });
        }

        public void StopPaymentTimer(int bookingId)
        {
            if (_activeTimers.TryRemove(bookingId, out var cts))
            {
                cts.Cancel(); // إلغاء المؤقت
                _logger.LogInformation("المؤقت للحجز {BookingId} تم إيقافه يدوياً.", bookingId);
            }
        }

        public void Dispose()
        {
            // عند إغلاق التطبيق، بنلغي كل المؤقتات اللي شغالة
            foreach (var cts in _activeTimers.Values)
            {
                cts.Cancel();
                cts.Dispose();
            }
            _activeTimers.Clear();
        }
    }
}
