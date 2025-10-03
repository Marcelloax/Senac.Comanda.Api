using Comandas.Api.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Comandas.Api.Controllers
{
    // CRIA A ROTA DO CONTROLADOR
    [Route("api/[controller]")]
    [ApiController]
    public class CardapioItemController : ControllerBase
    {
      
        public List<CardapioItem> cardapios = new List<CardapioItem>()
        {

            new CardapioItem
              {
                Id = 1,
                Titulo = "Coxinha",
                Descricao = "Deliciosa coxinha de frango com catupiry",
                Preco = 5.50M,
                PossuiPreparo = true
             },

             new CardapioItem
              {
                Id = 2,
                Titulo = "Pastel",
                Descricao = "Pastel de carne com queijo",
                Preco = 4.00M,
                PossuiPreparo = true
                }
         };
        [HttpGet] // ANOTACAO QUE INDICA SE O METODO RESPONDE A REQUISICOES GET
        public IResult GetCardapios()
        {
            return Results.Ok(cardapios);
        }
        [HttpGet("{id}")]
        public IResult Get(int id)
        
       {
            var cardapio = cardapios.FirstOrDefault(c => c.Id == id);
            if (cardapio == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(cardapio);
        }

        // POST api/<CardapioItemController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CardapioItemController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CardapioItemController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
