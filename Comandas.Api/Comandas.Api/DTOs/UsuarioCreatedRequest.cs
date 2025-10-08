namespace Comandas.Api.DTOs
{
    public class UsuarioCreatedRequest
    {
        public string Nome { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Senha { get; set; } = default!;
    }
}
