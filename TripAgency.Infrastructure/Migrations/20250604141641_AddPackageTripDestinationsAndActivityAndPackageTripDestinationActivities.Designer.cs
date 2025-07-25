﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TripAgency.Infrastructure.Context;

#nullable disable

namespace TripAgency.Infrastructure.Migrations
{
    [DbContext(typeof(TripAgencyDbContext))]
    [Migration("20250604141641_AddPackageTripDestinationsAndActivityAndPackageTripDestinationActivities")]
    partial class AddPackageTripDestinationsAndActivityAndPackageTripDestinationActivities
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TripAgency.Data.Entities.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Activities", (string)null);
                });

            modelBuilder.Entity("TripAgency.Data.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar");

                    b.HasKey("Id");

                    b.ToTable("Cities", (string)null);
                });

            modelBuilder.Entity("TripAgency.Data.Entities.Destination", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Destinations", (string)null);
                });

            modelBuilder.Entity("TripAgency.Data.Entities.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("MidPriceForOneNight")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<byte>("Rate")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Hotels", (string)null);
                });

            modelBuilder.Entity("TripAgency.Data.Entities.PackageTrip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CancellationPolicy")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int>("MaxCapacity")
                        .HasColumnType("int");

                    b.Property<int>("MinCapacity")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TripId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TripId");

                    b.ToTable("PackageTrips", (string)null);
                });

            modelBuilder.Entity("TripAgency.Data.Entities.PackageTripDestination", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DestinationId")
                        .HasColumnType("int");

                    b.Property<int>("PackageTripId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DestinationId");

                    b.HasIndex("PackageTripId");

                    b.ToTable("PackageTripDestinations", (string)null);
                });

            modelBuilder.Entity("TripAgency.Data.Entities.PackageTripDestinationActivity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ActivityId")
                        .HasColumnType("int");

                    b.Property<int>("PackageTripDestinationId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ActivityId");

                    b.HasIndex("PackageTripDestinationId");

                    b.ToTable("PackageTripDestinationActivities", (string)null);
                });

            modelBuilder.Entity("TripAgency.Data.Entities.PackageTripType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PackageTripId")
                        .HasColumnType("int");

                    b.Property<int>("TypeTripId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PackageTripId");

                    b.HasIndex("TypeTripId");

                    b.ToTable("PackageTripTypes", (string)null);
                });

            modelBuilder.Entity("TripAgency.Data.Entities.Trip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Trips", (string)null);
                });

            modelBuilder.Entity("TripAgency.Data.Entities.TypeTrip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("TypeTrips", (string)null);
                });

            modelBuilder.Entity("TripAgency.Data.Entities.Destination", b =>
                {
                    b.HasOne("TripAgency.Data.Entities.City", "City")
                        .WithMany("Destinations")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("TripAgency.Data.Entities.Hotel", b =>
                {
                    b.HasOne("TripAgency.Data.Entities.City", "City")
                        .WithMany("Hotels")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("TripAgency.Data.Entities.PackageTrip", b =>
                {
                    b.HasOne("TripAgency.Data.Entities.Trip", "Trip")
                        .WithMany("TripList")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("TripAgency.Data.Entities.PackageTripDestination", b =>
                {
                    b.HasOne("TripAgency.Data.Entities.Destination", "Destination")
                        .WithMany("PackageTripDestinations")
                        .HasForeignKey("DestinationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TripAgency.Data.Entities.PackageTrip", "PackageTrip")
                        .WithMany("PackageTripDestinations")
                        .HasForeignKey("PackageTripId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Destination");

                    b.Navigation("PackageTrip");
                });

            modelBuilder.Entity("TripAgency.Data.Entities.PackageTripDestinationActivity", b =>
                {
                    b.HasOne("TripAgency.Data.Entities.Activity", "Activity")
                        .WithMany("PackageTripDestinationActivities")
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TripAgency.Data.Entities.PackageTripDestination", "PackageTripDestination")
                        .WithMany("PackageTripDestinationActivities")
                        .HasForeignKey("PackageTripDestinationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Activity");

                    b.Navigation("PackageTripDestination");
                });

            modelBuilder.Entity("TripAgency.Data.Entities.PackageTripType", b =>
                {
                    b.HasOne("TripAgency.Data.Entities.PackageTrip", "PackageTrip")
                        .WithMany("PackageTripTypes")
                        .HasForeignKey("PackageTripId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TripAgency.Data.Entities.TypeTrip", "TypeTrip")
                        .WithMany("PackageTripTypes")
                        .HasForeignKey("TypeTripId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("PackageTrip");

                    b.Navigation("TypeTrip");
                });

            modelBuilder.Entity("TripAgency.Data.Entities.Activity", b =>
                {
                    b.Navigation("PackageTripDestinationActivities");
                });

            modelBuilder.Entity("TripAgency.Data.Entities.City", b =>
                {
                    b.Navigation("Destinations");

                    b.Navigation("Hotels");
                });

            modelBuilder.Entity("TripAgency.Data.Entities.Destination", b =>
                {
                    b.Navigation("PackageTripDestinations");
                });

            modelBuilder.Entity("TripAgency.Data.Entities.PackageTrip", b =>
                {
                    b.Navigation("PackageTripDestinations");

                    b.Navigation("PackageTripTypes");
                });

            modelBuilder.Entity("TripAgency.Data.Entities.PackageTripDestination", b =>
                {
                    b.Navigation("PackageTripDestinationActivities");
                });

            modelBuilder.Entity("TripAgency.Data.Entities.Trip", b =>
                {
                    b.Navigation("TripList");
                });

            modelBuilder.Entity("TripAgency.Data.Entities.TypeTrip", b =>
                {
                    b.Navigation("PackageTripTypes");
                });
#pragma warning restore 612, 618
        }
    }
}
