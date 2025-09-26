namespace Comandas.Api.Models
{
    public class PedidoCozinhaItem
    {
        public int Id { get; set; }
        public int PedidoCozinhaId { get; set; }
        public int ComandaItemId { get; set; }
    }
}
