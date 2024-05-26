﻿// <auto-generated />
using CompAerea.Infrastrutura.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CompAerea.Infrastrutura.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240526165404_AddFlightToDb")]
    partial class AddFlightToDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CompAerea.Dominio.Entidades.Flight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FlightFrom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FlightTo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Plane")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Seats")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Flights");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Fast plane with lots of seats",
                            FlightFrom = "Portugal",
                            FlightTo = "Italy",
                            ImageUrl = "https://placehold.co/600x400",
                            Plane = "Airbus A300",
                            Price = 25000.0,
                            Seats = 200
                        },
                        new
                        {
                            Id = 2,
                            Description = "Comercial plane with Origin in France and Italy ",
                            FlightFrom = "France",
                            FlightTo = "Italy",
                            ImageUrl = "https://placehold.co/600x400",
                            Plane = "ATR 72",
                            Price = 30000.0,
                            Seats = 125
                        },
                        new
                        {
                            Id = 3,
                            Description = "A Turboprop Regional Airliner",
                            FlightFrom = "France",
                            FlightTo = "Switzerland",
                            ImageUrl = "https://placehold.co/600x400",
                            Plane = "ATR 42",
                            Price = 15000.0,
                            Seats = 80
                        });
                });

            modelBuilder.Entity("CompAerea.Dominio.Entidades.FlightNumber", b =>
                {
                    b.Property<int>("Flight_Number")
                        .HasColumnType("int");

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FlightId")
                        .HasColumnType("int");

                    b.HasKey("Flight_Number");

                    b.HasIndex("FlightId");

                    b.ToTable("FlightNumber");

                    b.HasData(
                        new
                        {
                            Flight_Number = 101,
                            FlightId = 1
                        },
                        new
                        {
                            Flight_Number = 102,
                            FlightId = 1
                        },
                        new
                        {
                            Flight_Number = 103,
                            FlightId = 1
                        },
                        new
                        {
                            Flight_Number = 104,
                            FlightId = 1
                        },
                        new
                        {
                            Flight_Number = 201,
                            FlightId = 2
                        },
                        new
                        {
                            Flight_Number = 202,
                            FlightId = 2
                        },
                        new
                        {
                            Flight_Number = 203,
                            FlightId = 2
                        },
                        new
                        {
                            Flight_Number = 301,
                            FlightId = 3
                        },
                        new
                        {
                            Flight_Number = 302,
                            FlightId = 3
                        });
                });

            modelBuilder.Entity("CompAerea.Dominio.Entidades.FlightNumber", b =>
                {
                    b.HasOne("CompAerea.Dominio.Entidades.Flight", "Flight")
                        .WithMany()
                        .HasForeignKey("FlightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Flight");
                });
#pragma warning restore 612, 618
        }
    }
}