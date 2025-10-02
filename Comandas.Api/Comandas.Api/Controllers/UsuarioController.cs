using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Comandas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        List<string> usuarios = new List<string>()
        {
            new UsuarioController
            {
                id = 1,
                nome = "Admin",
            },
            new UsuarioController
            {
                id = 2,
                nome = "Garçom",
            }
        };

        [HttpGet]
        public IResult GetUsuario()
        {
            return Results.Ok(Usuarios);
        }
        [HttpGet("{id}")]
        public IResult Get(int id)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(usuario);
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
