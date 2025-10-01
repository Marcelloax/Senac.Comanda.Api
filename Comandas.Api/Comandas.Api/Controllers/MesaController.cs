using System.Security.Cryptography.X509Certificates;
using Comandas.Api.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Comandas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MesaController : ControllerBase
    {
        // GET: api/<MesaController>

        public List<Mesa> Mesas = new List<Mesa>()
        {
             new Mesa
             {
                 Id = 1,
                 NumeroMesa = 1,
                 SituacaoMesa = (int)SituacaoMesa.Livre
             },
             new Mesa
             {
                 Id = 2,
                 NumeroMesa = 2,
                 SituacaoMesa = (int)SituacaoMesa.Ocupada
             } 
        };
        [HttpGet]

        public IResult GetMesa()
        {
            return Results.Ok(Mesas);
        }
        [HttpGet("{id}")]
        public IResult Get(int id)
        {
            var Mesa = Mesas.FirstOrDefault(x => x.Id == id);
            if (Mesa == null)
            {
                return Results.NotFound("Não Encontrada!");
            }
            return Results.Ok(Mesa);
        }

        // POST api/<MesaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MesaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MesaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
