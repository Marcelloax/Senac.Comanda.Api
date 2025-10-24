namespace Comandas.Api.DTOs
{
    public class PedidoCozinhaCreatedRequest
    {
        public int Id { get; set; }
        public int ComandaId { get; set; }
        public List<PedidoCozinhaItemCreatedRequest> Itens { get; set; } = [];

    }
    public class PedidoCozinhaItemCreatedRequest
    {
        public int Id { get; set; }
        public int PedidoCozinhaId { get; set; }
        public int ComandaItemId { get; set; }
    }
}
