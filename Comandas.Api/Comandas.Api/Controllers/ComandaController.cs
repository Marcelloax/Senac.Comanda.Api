using Comandas.Api.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Comandas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComandaController : ControllerBase
    {
       public List<Comanda> list = new List<Comanda>()
        {   
            new Comanda
            {
                Id = 1,
                Itens = new List<ComandaItem>
                {
                    new ComandaItem
                    {
                        Id = 1,
                        CardapioItemId = 1, 
                        ComnandaItemId = 1
                    },
                    new ComandaItem
                    {
                        Id = 2,
                       CardapioItemId = 2,
                    }
                },
                NomeCliente = "João",
                NumeroMesa = 3
            },
            new Comanda
            {
                Id = 2,
                Itens = new List<ComandaItem>
                {
                    new ComandaItem
                    {
                        Id = 3,
                        CardapioItemId = 3,
                        ComnandaItemId = 2
                    },
                    new ComandaItem
                    {
                        Id = 4,
                        CardapioItemId = 4,
                    }
                },
                NomeCliente = "Maria",
                NumeroMesa = 5
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
