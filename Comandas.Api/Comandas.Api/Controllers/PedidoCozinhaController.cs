using Comandas.Api.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Comandas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoCozinhaController : ControllerBase
    {
       public List<PedidoCozinha> pedidosCozinha = new List<PedidoCozinha>()
        {
            new PedidoCozinha
              {
                Id = 1,
                ComandaId = 1,
                Itens = new List<PedidoCozinhaItem>
                {
                    new PedidoCozinhaItem
                    {
                        Id = 1,
                       ComandaItemId = 1,
                       PedidoCozinhaId = 1


                    },
                    new PedidoCozinhaItem
                    {
                        Id = 2,
                      ComandaItemId = 2,
                      PedidoCozinhaId = 1

                    }
                }
             },
             new PedidoCozinha
              {
                Id = 2,
                ComandaId = 2,

                }
         };
        [HttpGet]
        public IResult GetPedido()
        {
            return Results.Ok(pedidosCozinha);
        }

        [HttpGet("{id}")]
        public IResult Get(int id)
        {
            var pedidoCozinha = pedidosCozinha.FirstOrDefault(c => c.Id == id);
            if (pedidoCozinha == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(pedidoCozinha);
        }

        // POST api/<PedidoCozinhaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PedidoCozinhaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PedidoCozinhaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
