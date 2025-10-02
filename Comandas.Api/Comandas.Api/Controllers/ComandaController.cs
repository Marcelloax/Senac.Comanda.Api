using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Comandas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComandaController : ControllerBase
    {
        List<ComandaController> list = new List<ComandaController>();
        {   new ComandaController
            {
                Id = 1,
                NumeroComanda = 1,
                SituacaoComanda = (int)SituacaoComanda.Aberta
            },
            new ComandaController
            {
                Id = 2,
                NumeroComanda = 2,
                SituacaoComanda = (int)SituacaoComanda.Fechada
            }
        };

        [HttpGet]
        public IResult GetComanda()
        {
            return Results.Ok(list);
        }

        [HttpGet("{id}")]
        public IResult Get(int id)
        {
            var comanda = list.FirstOrDefault(x => x.Id == id);
            if (comanda == null)
            {
                return Results.NotFound("Não Encontrada!");
            }
            return Results.Ok(comanda);
}

// POST api/<ComandaController>
[HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ComandaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ComandaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
