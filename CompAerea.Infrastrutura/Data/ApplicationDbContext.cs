using CompAerea.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace CompAerea.Infrastrutura.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
		public DbSet<FlightNumber> FlightNumber { get; set; }
		public DbSet<Flight> Flights { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Flight>().HasData(
                  new Flight
                  {
                      Id = 1,
                      Plane = "Airbus A300",
                      Description = "Fast plane with lots of seats",
                      Price = 25000.00,
                      Seats = 200,
                      ImageUrl = "https://placehold.co/600x400",
                      FlightFrom = "Portugal",
                      FlightTo = "Italy",
                  },
                  new Flight
                  {
                      Id = 2,
                      Plane = "ATR 72",
                      Description = "Comercial plane with Origin in France and Italy ",
                      Price = 30000.00,
					  Seats = 125,
                      ImageUrl = "https://placehold.co/600x400",
					  FlightFrom = "France",
					  FlightTo = "Italy",
				  },
                  new Flight
                  {
                      Id = 3,
					  Plane = "ATR 42",
					  Description = "A Turboprop Regional Airliner",
					  Price = 15000.00,
                      Seats = 80,
                      ImageUrl = "https://placehold.co/600x400",
					  FlightFrom = "France",
					  FlightTo = "Switzerland",
				  }
                        );

			modelBuilder.Entity<FlightNumber>().HasData(
				new FlightNumber
				{
					Flight_Number = 101,
					FlightId = 1,

				},
				 new FlightNumber
				 {
					 Flight_Number = 102,
					 FlightId = 1,

				 },
				  new FlightNumber
				  {
					  Flight_Number = 103,
					  FlightId = 1,

				  },
				   new FlightNumber
				   {
					   Flight_Number = 104,
					   FlightId = 1,

				   },
					new FlightNumber
					{
						Flight_Number = 201,
						FlightId = 2,

					},
					new FlightNumber
					{
						Flight_Number = 202,
						FlightId = 2,

					},
					new FlightNumber
					{
						Flight_Number = 203,
						FlightId = 2,

					},
					new FlightNumber
					{
						Flight_Number = 301,
						FlightId = 3,

					},
					new FlightNumber
					{
						Flight_Number = 302,
						FlightId = 3,

					}
				);
		}

    }
}