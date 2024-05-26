using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CompAerea.Dominio.Entidades
{
	public class FlightNumber
	{

		
			[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
			[Display(Name = "Flight Number")]
			public int Flight_Number { get; set; }

			[ForeignKey("Flight")]
			public int FlightId { get; set; }

			[ValidateNever]
			public Flight Flight { get; set; } = null!;
			[Display(Name = "Extra Details")]
			public string? Details { get; set; }
		
	}
}
