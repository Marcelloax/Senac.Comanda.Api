namespace Comandas.Api.Models
{
    public class CardapioItem
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = default!;
        public string Descricao { get; set; } = default!;
        public decimal Preco { get; set; }
        public bool PossuiPreparo { get; set; }
    }
}
