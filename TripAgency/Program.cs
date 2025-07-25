
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using System.Text.Json;
using TripAgency.Api.Behavior;
using TripAgency.Data;
using TripAgency.Infrastructure;
using TripAgency.Infrastructure.Context;
using TripAgency.Middleware;
using TripAgency.Service;
using TripAgency.Service.Feature.City.Command.Validaters;
using TripAgency.Service.Mapping.City_Entity;


namespace TripAgency
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {



                var builder = WebApplication.CreateBuilder(args);

                // Add services to the container.

                builder.Services.AddControllers(op => op.Filters.Add(typeof(ValidationFilter)))
                    .ConfigureApiBehaviorOptions(options => options.InvalidModelStateResponseFactory = context => null!)
                    .AddJsonOptions(options =>
                    {
                        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                    });
                ;
                // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen(options =>
                {
                    options.MapType<TimeSpan>(() => new OpenApiSchema
                    {
                        Type = "string",
                        Example = new OpenApiString("00:00:00")
                    });
                });

                builder.Services.AddDbContext<TripAgencyDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

                builder.Services.AddServicesDependencies(builder.Configuration)
                                .AddInfrastructureDependencies();

                builder.Services.AddAutoMapper(typeof(CityProfile).Assembly);

                builder.Services.AddFluentValidationAutoValidation()
                                .AddValidatorsFromAssembly(typeof(AddCityDtoValidation).Assembly);

              
                var app = builder.Build();
                app.UseMiddleware<ErrorHandlerExceptionMiddleware>();
                // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

                app.UseHttpsRedirection();

                app.UseAuthorization();


                app.MapControllers();

                app.Run();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
