using System.Security.Cryptography.X509Certificates;

namespace Comandas.Api.DTOs
{
    public class ComandaUpdateRequest
    {
        public string NomeCliente { get; set; }
        public int[] CardapioItemIds { get; set; }
        public int NumeroMesa { get; set; }
    }
}
