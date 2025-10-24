using System.Security.Cryptography.X509Certificates;
using Comandas.Api.DTOs;
using Comandas.Api.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Comandas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MesaController : ControllerBase
    {
       public ComandasDbContext _context { get; set; }
    // Simulando um banco de dados em memória
       public MesaController(ComandasDbContext context)
        {
            _context = context;
        }

        [HttpGet]

        public IResult GetMesa()
        {
            var Mesas = _context.Mesas.ToList();
            return Results.Ok(Mesas);
        }
        [HttpGet("{id}")]
        public IResult Get(int id)
        {
            var Mesa = _context.Mesas;
            if (Mesa is null)
            {
                return Results.NotFound("Não Encontrada!");
            }
            return Results.Ok(Mesa);
        }

        // POST api/<MesaController>
        [HttpPost]
        public IResult Post([FromBody] MesaCreatedRequest mesaCreated)
        {
            if (mesaCreated. NumeroMesa < 1)
                return Results.BadRequest("O número da mesa deve ser maior que 0.");
            if (mesaCreated.SituacaoMesa < 0 || mesaCreated.SituacaoMesa > 2)
                return Results.BadRequest("A situação da mesa deve ser entre 0 e 2.");
            var mesa = new Mesa
            {
                NumeroMesa = mesaCreated.NumeroMesa,
                SituacaoMesa = mesaCreated.SituacaoMesa
            };
            _context.Mesas.Add(mesa);
            _context.SaveChanges();
            return Results.Created($"/api/mesa/{mesa.Id}", mesa);
        }




        // PUT api/<MesaController>/5
        [HttpPut("{id}")]
        public IResult Put(int id, [FromBody] MesaUpdateRequest mesaUpdate )
        {
            var mesa = _context.Mesas.FirstOrDefault(u => u.Id == id );
            if (mesa is null)
            
                return Results.NotFound( $"Mesa do id {id} não foi encontrada!!  " );
            
            mesa.NumeroMesa = mesaUpdate.NumeroMesa;
            mesa.SituacaoMesa = mesaUpdate.SituacaoMesa;
            _context.SaveChanges();
            return Results.NoContent();
        }

        // DELETE api/<MesaController>/5
        [HttpDelete("{id}")]
        public IResult Delete(int id)
        {
            var mesa = _context.Mesas.FirstOrDefault(u => u.Id == id);
            if (mesa is null)
                return Results.NotFound($"Mesa do id {id} não foi encontrada!");
            _context.Mesas.Remove(mesa);
            var remove = _context.SaveChanges();
            if (remove > 0)
            {
                return Results.NoContent();
            }
            return Results.StatusCode(500);
        }
    }
}
