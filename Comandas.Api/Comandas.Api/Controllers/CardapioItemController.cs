using Comandas.Api.DTOs;
using Comandas.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var cardapios = _context.CardapioItems.Include(c=> c.CategoriaCardapio).ToList();
            return Results.Ok(cardapios);
        }
        [HttpGet("{id}")]
        public IResult Get(int id)
        
        {
            var cardapio = _context.CardapioItems
                .Include(ci=> ci.CategoriaCardapio)
                .FirstOrDefault (c=> c.Id== id) ;
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

            if (cardapioItemUpdate.CategoriaCardapioId.HasValue)
            {
                var categoria = _context.CategoriaCardapios
                  .FirstOrDefault(c => c.Id == cardapioItemUpdate.CategoriaCardapioId);
                if (categoria is null)
                    return Results.BadRequest("Categoria de cardápio inválida.");
            }
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

        public IResult Put(int id, [FromBody] CardapioItemUpdateRequest cardapio)
        {

            var cardapioItem = _context.CardapioItems.
                FirstOrDefault(c => c.Id == id);
            if (cardapioItem is null)

                return Results.NotFound($"Cardápio {id} não encontrado!");

            // se categoria informada

            if (cardapio.CategoriaCardapioId.HasValue)

            {
                // consulta no banco pelo id da categoria
                var categoria = _context.CategoriaCardapios
                .FirstOrDefault(c => c.Id == cardapio.CategoriaCardapioId);
                // se o retorno da consulta retornou nulo
                if (categoria is null)
                return Results.BadRequest("Categoria de cardápio inválida.");
            }
            cardapioItem.Titulo = cardapio.Titulo;
            cardapioItem.Descricao = cardapio.Descricao;
            cardapioItem.Preco = cardapio.Preco;
            cardapioItem.PossuiPreparo = cardapio.PossuiPreparo;
            cardapioItem.CategoriaCardapioId = cardapio.CategoriaCardapioId;

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
