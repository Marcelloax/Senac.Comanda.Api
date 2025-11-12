using System.Security.Cryptography.X509Certificates;

namespace Comandas.Api.DTOs
{
    public class ComandaUpdateRequest
    {
        public string NomeCliente { get; set; }
        public int NumeroMesa { get; set; }
        public ComandaItemUpdateRequest[] Itens { get; set; } = [];
    }

    public class ComandaItemUpdateRequest
    {
        public int Id { get; set; }
        public bool Remove { get; set; }
        public int CardapioItemId { get; set; }

    }
}
