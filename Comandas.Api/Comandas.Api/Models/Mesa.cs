namespace Comandas.Api.Models
{
    public class Mesa
    {
        public int Id { get; set; }
        public int NumeroMesa { get; set; }
        public int SituacaoMesa { get; set; }
    }

    public enum SituacaoMesa
    {
        Livre = 0,
        Ocupada = 1
    }
}
