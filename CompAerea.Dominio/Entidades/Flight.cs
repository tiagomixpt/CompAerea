using System.ComponentModel.DataAnnotations;

namespace CompAerea.Dominio.Entidades
{
    public class Flight
    {
        public int Id { get; set; }
        public required string Plane { get; set; }
        
        public string? Description { get; set; }
		
		public double Price { get; set; }
       
        public int Seats { get; set; }
		[Display(Name = "Imagem")]
		public string? ImageUrl { get; set; }
		[Display(Name = "Flight From")]
		public string? FlightFrom { get; set; }
		[Display(Name = "Flight To")]
		public string? FlightTo { get; set; }
    }
}
