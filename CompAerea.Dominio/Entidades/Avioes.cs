namespace CompAerea.Dominio.Entidades
{
    public class Avioes
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public string? Descricao { get; set; }
        public double Preco { get; set; }
        public int Classe { get; set; }
        public int Passageiros { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? DataPartida { get; set; }
        public DateTime? DataChegada { get; set; }
    }
}
