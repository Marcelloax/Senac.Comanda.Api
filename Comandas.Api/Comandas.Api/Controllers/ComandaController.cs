using Comandas.Api.DTOs;
using Comandas.Api.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Comandas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComandaController : ControllerBase
    {
       public List<Comanda> comandas = new List<Comanda>()
        {   
            new Comanda
            {
                Id = 1,
                NomeCliente = "João",
                NumeroMesa = 3,
                Itens = new List<ComandaItem>
                {
                    new ComandaItem
                    {
                      Id = 1,
                      CardapioItemId = 1,
                      ComandaId = 1
                    },
                    new ComandaItem
                    {
                        Id = 2,
                        CardapioItemId = 2,
                        ComandaId = 2
                    },
                },
               
            },
            new Comanda
            {
                Id = 2,
                NomeCliente = "Maria",
                NumeroMesa = 4,
                Itens = new List<ComandaItem>
                {
                    new ComandaItem
                    {
                        Id = 3,
                        CardapioItemId = 1,
                        ComandaId = 2
                    },
                    new ComandaItem
                    {
                        Id = 4,
                        CardapioItemId = 2,
                        ComandaId = 2,
                    },
                },

            }
        };

        [HttpGet]
        public IResult GetComanda()
        {
            return Results.Ok(comandas);
        }

        [HttpGet("{id}")]
        public IResult Get(int id)
        {
            var comanda = comandas.FirstOrDefault(x => x.Id == id);
            if (comanda == null)
            {
                return Results.NotFound("Não Encontrada!");
            }
            return Results.Ok(comanda);
}

        // POST api/<ComandaController>
        [HttpPost]
        public IResult Post([FromBody] ComandaCreateRequest comandaCreate)
        {
            if (comandaCreate.NomeCliente.Length < 3)
                return Results.BadRequest("O nome do cliente deve ter no minimo 3 caracteres");
            if (comandaCreate.NumeroMesa <= 0)
                return Results.BadRequest("O numero da mesa deve ser maior que zero");
            if (comandaCreate.CardapioItemIds.Length == 0)
                return Results.BadRequest("A comanda deve ter pelo menos um item do cardapio");
            var novacomanda = new Comanda
            {
                Id = comandas.Count + 1,
                NomeCliente = comandaCreate.NomeCliente,
                NumeroMesa = comandaCreate.NumeroMesa,
            };
            var comandaItens = new List<ComandaItem>();
            novacomanda.Itens = comandaItens;
            foreach (int cardapioItemId in comandaCreate.CardapioItemIds)
            {
                var comandaItem = new ComandaItem
                {
                    Id = comandaItens.Count + 1,
                    CardapioItemId = cardapioItemId,
                    ComandaId = novacomanda.Id
                };
                comandaItens.Add(comandaItem);
            }
            novacomanda.Itens = comandaItens;
            comandas.Add(novacomanda);
            return Results.Created($"/api/comanda/{novacomanda.Id}", novacomanda); }

            // PUT api/<ComandaController>/5
            [HttpPut("{id}")]
        public IResult Put(int id, [FromBody] ComandaUpdateRequest comandaUpdate )
        {
            var comanda = comandas.FirstOrDefault(c => c.Id == id);
            if (comanda == null)
            
                return Results.NotFound("Comanda não encontrada!");
            if (comandaUpdate.NomeCliente.Length < 3)
                return Results.BadRequest("O nome do cliente deve ter no minimo 3 caracteres");
            if (comandaUpdate.NumeroMesa <= 0)
                return Results.BadRequest("O numero da mesa deve ser maior que zero");
            comanda.NomeCliente = comandaUpdate.NomeCliente;
            comanda.NumeroMesa = comandaUpdate.NumeroMesa;

            return Results.NoContent();
        }

        // DELETE api/<ComandaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
