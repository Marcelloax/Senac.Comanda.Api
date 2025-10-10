using Comandas.Api.DTOs;
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
            if (cardapio is null)
            {
                return Results.NotFound();
            }
            return Results.Ok(cardapio);
        }

        // POST api/<CardapioItemController>
        [HttpPost]
        public IResult Post([FromBody] CardapioItemUpdateRequest cardapioItemUpdate)
        {
            if (cardapioItemUpdate.Titulo.Length < 3)
                return Results.BadRequest("O título deve ter no mínimo 3 caracteres.");
            if (cardapioItemUpdate.Descricao.Length < 5)
                return Results.BadRequest("A descrição deve ter no mínimo 5 caracteres.");
            if (cardapioItemUpdate.Preco <= 0)
                return Results.BadRequest("O preço deve ser maior que zero.");
            var novoItem = new CardapioItem
            {
                Id = cardapios.Count + 1,
                Titulo = cardapioItemUpdate.Titulo,
                Descricao = cardapioItemUpdate.Descricao,
                Preco = cardapioItemUpdate.Preco,
                PossuiPreparo = cardapioItemUpdate.PossuiPreparo
            };
            cardapios.Add(novoItem);
            return Results.Created($"/api/cardapioitem/{novoItem.Id}", novoItem);
        }

        // PUT api/<CardapioItemController>/5
        [HttpPut("{id}")]
        public IResult Put(int id, [FromBody] CardapioItemUpdateRequest cardapioItemUpdate)
        {
            var cardapio = cardapios.FirstOrDefault(c => c.Id == id);
            if (cardapio == null)
            {
                return Results.NotFound($"Item do cardápio ID {id} não foi encontrado!");
            }
            cardapio.Titulo = cardapioItemUpdate.Titulo;
            cardapio.Descricao = cardapioItemUpdate.Descricao;
            cardapio.Preco = cardapioItemUpdate.Preco;
            cardapio.PossuiPreparo = cardapioItemUpdate.PossuiPreparo;
            return Results.NoContent();
        }

        // DELETE api/<CardapioItemController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
