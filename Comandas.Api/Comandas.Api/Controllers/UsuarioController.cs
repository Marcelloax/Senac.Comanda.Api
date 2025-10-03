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

        // POST api/<UsuarioController>
        [HttpPost]
        public IResult Post([FromBody] Usuario usuario)
        {
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
