using Comandas.Api.DTOs;
using Comandas.Api.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Comandas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        static List<Usuario> usuarios = new List<Usuario>()
        {
            new Usuario
            {
               Id = 1,
                Nome = "Cozinheiro",
                Email = "cozinheiro@gmail.com",
                Senha = "123456"
            },
            new Usuario
            {
                Id = 2,
                Nome = "Garçom",
                Email = "garlom@gmail.com",
                Senha = "123456"
            }
        };

        [HttpGet]
        public IResult GetUsuario()
        {
            return Results.Ok(usuarios);
        }
        [HttpGet("{id}")]
        public IResult Get(int id)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario == null)
            {
                return Results.NotFound("Usuario não encontrado!");
            }
            return Results.Ok(usuario);
        }

        // POST api/<MesaController>
        [HttpPost]
        public IResult Post([FromBody] UsuarioCreatedRequest usuarioCreated)
        {
            if (usuarioCreated.Senha.Length < 6)

                return Results.BadRequest("A senha deve ter no mínimo 6 caracteres.");

            if (usuarioCreated.Nome.Length < 3)

                return Results.BadRequest("O nome deve ter no mínimo 3 caracteres.");

            if (usuarioCreated.Email.Length < 6 || !usuarioCreated.Email.Contains("@"))

                return Results.BadRequest("O email deve ser valido");
            var usuario = new Usuario
            {
                Id = usuarios.Count + 1,
                Nome = usuarioCreated.Nome,
                Email = usuarioCreated.Email,
                Senha = usuarioCreated.Senha
            };
            usuarios.Add(usuario);
            return Results.Created($"/api/usuario/{usuario.Id}", usuario);
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
