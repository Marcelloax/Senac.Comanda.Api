namespace Comandas.Api.DTOs
{
    public class LoginRequest
    {
        public string Email { get; set; } = default!;
        public string Senha { get; set; } = default!;
    }
}
