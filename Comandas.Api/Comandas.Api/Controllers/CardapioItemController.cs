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
           public ComandasDbContext _context { get; set; }
        // Simulando um banco de dados em memória
        public CardapioItemController(ComandasDbContext context)
        { _context = context; }

        [HttpGet] // ANOTACAO QUE INDICA SE O METODO RESPONDE A REQUISICOES GET
        public IResult GetCardapios()
        {
            var cardapios = _context.CardapioItems.ToList();
            return Results.Ok(cardapios);
        }
        [HttpGet("{id}")]
        public IResult Get(int id)
        
        {
            var cardapio = _context.CardapioItems;
            if (cardapio is null)
            {
                return Results.NotFound($"Item do cardápio ID {id} não foi encontrado!");
            }
            return Results.Ok(cardapio);
        }

        // POST api/<CardapioItemController>
        [HttpPost]
        public IResult Post([FromBody] CardapioItemCreatedRequest cardapioItemUpdate)
        {
            if (cardapioItemUpdate.Titulo.Length < 3)
                return Results.BadRequest("O título deve ter no mínimo 3 caracteres.");
            if (cardapioItemUpdate.Descricao.Length < 5)
                return Results.BadRequest("A descrição deve ter no mínimo 5 caracteres.");
            if (cardapioItemUpdate.Preco <= 0)
                return Results.BadRequest("O preço deve ser maior que zero.");
            var novoItem = new CardapioItem
            {
                Titulo = cardapioItemUpdate.Titulo,
                Descricao = cardapioItemUpdate.Descricao,
                Preco = cardapioItemUpdate.Preco,
                PossuiPreparo = cardapioItemUpdate.PossuiPreparo,
                CategoriaCardapioId = cardapioItemUpdate.CategoriaCardapioId
            };

            _context.CardapioItems.Add(novoItem);
            return Results.Created($"/api/cardapioitem/{novoItem.Id}", novoItem);
        }

            // PUT api/<CardapioItemController>/5
            [HttpPut("{id}")]
        public IResult Put(int id, [FromBody] CardapioItemUpdateRequest cardapioItemUpdate)
        {
            var cardapio = _context.CardapioItems;
            if (cardapio is null)
                return Results.NotFound($"Item do cardápio ID {id} não foi encontrado!");
           
            _context.SaveChanges();
            return Results.NoContent();
        }

        // DELETE api/<CardapioItemController>/5
        [HttpDelete("{id}")]
        public IResult Delete(int id)
        {
            var cardapio = _context.CardapioItems;
            if (cardapio is null)
                return Results.NotFound($"Item do cardápio ID {id} não foi encontrado!");

            _context.SaveChanges();
            return Results.NoContent();
        }
    }
}
