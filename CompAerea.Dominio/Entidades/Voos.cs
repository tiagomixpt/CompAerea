using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CompAerea.Dominio.Entidades
{
	public class Voos
	{

		
			[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
			[Display(Name = "Numero do Voo")]
			public int Numero_Voo { get; set; }

			[ForeignKey("AvioesId")]

			public int AvioesId { get; set; }
			[ValidateNever]
			public Avioes Avioes { get; set; } = null!;
			[Display(Name = "Detalhes adicionais")]
			public string? Details { get; set; }
		
	}
}
