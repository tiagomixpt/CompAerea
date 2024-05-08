using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompAerea.Dominio.Entidades
{
	public class Voos
	{

		
			[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
			[Display(Name = "Numero do Voo")]
			public int Numero_Voo { get; set; }

			[ForeignKey("Villa")]

			public int VooId { get; set; }
			[ValidateNever]
			public Avioes Voo { get; set; } = null!;
			[Display(Name = "Detalhes adicionais")]
			public string? Details { get; set; }
		
	}
}
