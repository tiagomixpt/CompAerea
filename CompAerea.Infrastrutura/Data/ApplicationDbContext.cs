﻿using CompAerea.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace CompAerea.Infrastrutura.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
		public DbSet<Avioes> Avioes { get; set; }
		public DbSet<Voos> Voos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Avioes>().HasData(
                  new Avioes
                  {
                      Id = 1,
                      Nome = "Airbus A300",
                      Descricao = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                      Preco = 25000.00,
                      Classe = 5,
                      Passageiros = 200,
                      ImageUrl = "https://placehold.co/600x400",
                      DataPartida = "2013/02/12",
                      DataChegada = "2013/02/12",
                  },
                  new Avioes
                  {
                      Id = 2,
                      Nome = "ATR 72",
                      Descricao = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                      Preco = 30000.00,
                      Classe = 10,
                      Passageiros = 125,
                      ImageUrl = "https://placehold.co/600x400",
                      DataPartida = "2013/02/12",
                      DataChegada = "2013/02/12",
                  },
                  new Avioes
                  {
                      Id = 3,
                      Nome = "Cessna 120",
                      Descricao = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                      Preco = 15000.00,
                      Classe = 2,
                      Passageiros = 12,
                      ImageUrl = "https://placehold.co/600x400",
                      DataPartida = "2013/02/12",
                      DataChegada = "2013/02/12",
                  }
                        );

			modelBuilder.Entity<Voos>().HasData(
				new Voos
				{
					Numero_Voo = 111,
					AvioesId = 1,

				},
				 new Voos
				 {
					 Numero_Voo = 102,
					 AvioesId = 1,

				 },
				  new Voos
				  {
					  Numero_Voo = 103,
					  AvioesId = 1,

				  },
				   new Voos
				   {
					   Numero_Voo = 104,
					   AvioesId = 1,

				   },
					new Voos
					{
						Numero_Voo = 201,
						AvioesId = 2,

					},
					new Voos
					{
						Numero_Voo = 202,
						AvioesId = 2,

					},
					new Voos
					{
						Numero_Voo = 203,
						AvioesId = 2,

					},
					new Voos
					{
						Numero_Voo = 301,
						AvioesId = 3,

					},
					new Voos
					{
						Numero_Voo = 302,
						AvioesId = 3,

					}
				);
		}

    }
}