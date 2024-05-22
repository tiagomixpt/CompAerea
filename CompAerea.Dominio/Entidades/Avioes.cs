using System.ComponentModel.DataAnnotations;
namespace CompAerea.Dominio.Entidades
{
    public class Avioes
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        [Display(Name = "Descrição")]
        public string? Descricao { get; set; }
		[Display(Name = "Preço")]
		public double Preco { get; set; }
        public int Classe { get; set; }
        public int Passageiros { get; set; }
		[Display(Name = "Imagem")]
		public string? ImageUrl { get; set; }
		[Display(Name = "Data de Partida")]
		public string? DataPartida { get; set; }
		[Display(Name = "Data de Chegada")]
		public string? DataChegada { get; set; }
    }
}
