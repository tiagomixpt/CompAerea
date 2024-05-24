﻿// <auto-generated />
using CompAerea.Infrastrutura.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CompAerea.Infrastrutura.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CompAerea.Dominio.Entidades.Avioes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Classe")
                        .HasColumnType("int");

                    b.Property<string>("DataChegada")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DataPartida")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Passageiros")
                        .HasColumnType("int");

                    b.Property<double>("Preco")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Avioes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Classe = 5,
                            DataChegada = "2013/02/12",
                            DataPartida = "2013/02/12",
                            Descricao = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                            ImageUrl = "https://placehold.co/600x400",
                            Nome = "Airbus A300",
                            Passageiros = 200,
                            Preco = 25000.0
                        },
                        new
                        {
                            Id = 2,
                            Classe = 10,
                            DataChegada = "2013/02/12",
                            DataPartida = "2013/02/12",
                            Descricao = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                            ImageUrl = "https://placehold.co/600x400",
                            Nome = "ATR 72",
                            Passageiros = 125,
                            Preco = 30000.0
                        },
                        new
                        {
                            Id = 3,
                            Classe = 2,
                            DataChegada = "2013/02/12",
                            DataPartida = "2013/02/12",
                            Descricao = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                            ImageUrl = "https://placehold.co/600x400",
                            Nome = "Cessna 120",
                            Passageiros = 12,
                            Preco = 15000.0
                        });
                });

            modelBuilder.Entity("CompAerea.Dominio.Entidades.Voos", b =>
                {
                    b.Property<int>("Numero_Voo")
                        .HasColumnType("int");

                    b.Property<int>("AvioesId")
                        .HasColumnType("int");

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Numero_Voo");

                    b.HasIndex("AvioesId");

                    b.ToTable("Voos");

                    b.HasData(
                        new
                        {
                            Numero_Voo = 111,
                            AvioesId = 1
                        },
                        new
                        {
                            Numero_Voo = 102,
                            AvioesId = 1
                        },
                        new
                        {
                            Numero_Voo = 103,
                            AvioesId = 1
                        },
                        new
                        {
                            Numero_Voo = 104,
                            AvioesId = 1
                        },
                        new
                        {
                            Numero_Voo = 201,
                            AvioesId = 2
                        },
                        new
                        {
                            Numero_Voo = 202,
                            AvioesId = 2
                        },
                        new
                        {
                            Numero_Voo = 203,
                            AvioesId = 2
                        },
                        new
                        {
                            Numero_Voo = 301,
                            AvioesId = 3
                        },
                        new
                        {
                            Numero_Voo = 302,
                            AvioesId = 3
                        });
                });

            modelBuilder.Entity("CompAerea.Dominio.Entidades.Voos", b =>
                {
                    b.HasOne("CompAerea.Dominio.Entidades.Avioes", "Avioes")
                        .WithMany()
                        .HasForeignKey("AvioesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Avioes");
                });
#pragma warning restore 612, 618
        }
    }
}
