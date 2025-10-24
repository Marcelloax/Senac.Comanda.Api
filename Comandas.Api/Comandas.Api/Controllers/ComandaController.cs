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
       public ComandasDbContext _context { get; set; }
        // Simulando um banco de dados em memória
       public ComandaController(ComandasDbContext context)
        { _context = context; }
        [HttpGet]
        public IResult GetComanda()
        {
            var comandas = _context.Comandas.ToList();
            return Results.Ok(comandas);
        }

        [HttpGet("{id}")]
        public IResult Get(int id)
        {
            var comanda = _context.Comandas;
            if (comanda is null)
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
                NomeCliente = comandaCreate.NomeCliente,
                NumeroMesa = comandaCreate.NumeroMesa,
            };
            var comandaItens = new List<ComandaItem>();
            novacomanda.Itens = comandaItens;
            foreach (int cardapioItemId in comandaCreate.CardapioItemIds)
            {
                var comandaItem = new ComandaItem
                {
                    CardapioItemId = cardapioItemId,
                    ComandaId = novacomanda.Id
                };
            }
            _context.Comand as.Add(novacomanda);
            return Results.Created($"/api/comanda/{novacomanda.Id}", novacomanda); 
        }

        // PUT api/<ComandaController>/5
        [HttpPut("{id}")]
        public IResult Put(int id, [FromBody] ComandaUpdateRequest comandaUpdate )
        {
            var comanda = _context.Comandas.FirstOrDefault(c => c.Id == id);
                if (comanda is null)
            
                return Results.NotFound("Comanda não encontrada!");
            if (comandaUpdate.NomeCliente.Length < 3)
                return Results.BadRequest("O nome do cliente deve ter no minimo 3 caracteres");
            if (comandaUpdate.NumeroMesa <= 0)
                return Results.BadRequest("O numero da mesa deve ser maior que zero");
            comanda.NomeCliente = comandaUpdate.NomeCliente;
            comanda.NumeroMesa = comandaUpdate.NumeroMesa;
                _context.SaveChanges();

                return Results.NoContent();
        }

        // DELETE api/<ComandaController>/5
        [HttpDelete("{id}")]
        public IResult Delete(int id)
        {
            var comanda = _context.Comandas.FirstOrDefault(c => c.Id == id);
            if (comanda is null)
                return Results.NotFound($"Comanda do id {id} não encontrada");
            _context.Comandas.Remove(comanda);
            var removido = _context.SaveChanges();
            if (removido > 0)
            {
                return Results.NoContent();
            } 
            return Results.StatusCode(500);
        }
    }
}
