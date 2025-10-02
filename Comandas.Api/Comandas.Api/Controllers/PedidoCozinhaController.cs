using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Comandas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoCozinhaController : ControllerBase
    {
        List<PedidoCozinhaController> pedidosCozinha = new List<PedidoCozinhaController>()
        {
            new PedidoCozinhaController
              {
                Id = 1,
                Titulo = "Coxinha",
                Descricao = "Deliciosa coxinha de frango com catupiry",
                Preco = 5.50M,
                PossuiPreparo = true
             },
             new PedidoCozinhaController
              {
                Id = 2,
                Titulo = "Pastel",
                Descricao = "Pastel de carne com queijo",
                Preco = 4.00M,
                PossuiPreparo = true
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
