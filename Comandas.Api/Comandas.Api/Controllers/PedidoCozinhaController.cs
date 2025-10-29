using Comandas.Api.DTOs;
using Comandas.Api.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Comandas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoCozinhaController : ControllerBase
    {
        // Simulando um banco de dados em memória
         public ComandasDbContext _context { get; set; }
        public PedidoCozinhaController(ComandasDbContext context)
        { _context = context; }
        [HttpGet]
        public IResult GetPedido()
        {
            var pedidosCozinha = _context.PedidoCozinhas.ToList();
            return Results.Ok(pedidosCozinha);
        }

        [HttpGet("{id}")]
        public IResult Get(int id)
        {
            var pedidoCozinha = _context.PedidoCozinhas;
            if (pedidoCozinha is null)
            {
                return Results.NotFound("Não encontrado");
            }
            return Results.Ok(pedidoCozinha);
        }

        // POST api/<PedidoCozinhaController>
        [HttpPost]
        public IResult Post([FromBody] PedidoCozinhaCreatedRequest pedidoCozinhaCreated)
        {
            if (pedidoCozinhaCreated.Itens.Count == 0)
                return Results.BadRequest("O pedido de cozinha deve ter pelo menos um item.");
            var novoPedidoCozinha = new PedidoCozinha
            {
                ComandaId = pedidoCozinhaCreated.ComandaId,
            };
            var pedidoCozinhaItens = new List<PedidoCozinhaItem>();
            novoPedidoCozinha.Itens = pedidoCozinhaItens;
            foreach (var item in pedidoCozinhaCreated.Itens)
            {
                var pedidoCozinhaItem = new PedidoCozinhaItem
                {
                    ComandaItemId = item.ComandaItemId,
                    PedidoCozinhaId = novoPedidoCozinha.Id
                };


                _context.PedidoCozinhas.Add(novoPedidoCozinha);
                
            }
            _context.SaveChanges();
            return Results.Created($"/api/pedidocozinha/{novoPedidoCozinha.Id}", novoPedidoCozinha);

        }

        // PUT api/<PedidoCozinhaController>/5
        [HttpPut("{id}")]
        public IResult Put(int id, [FromBody] PedidoCozinhaUpdateRequest pedidoCozinhaUpdate)

        {
            var pedidoCozinha = _context.PedidoCozinhas.FirstOrDefault(p => p.Id == id);
            if (pedidoCozinha is null)
             return Results.NotFound("Pedido de cozinha não encontrado!");
            _context.SaveChanges();
            return Results.NoContent();
        }

        // DELETE api/<PedidoCozinhaController>/5
        [HttpDelete("{id}")]
        public IResult Delete(int id)
        {
            var pedidoCozinha = _context.PedidoCozinhas.
                FirstOrDefault(p => p.Id == id);
            if (pedidoCozinha is null)
                return Results.NotFound($"Pedido de cozinha do id {id} não foi encontrado!");
            _context.PedidoCozinhas.Remove(pedidoCozinha);
            _context.SaveChanges();
            return Results.NoContent();
        }
    }
}
