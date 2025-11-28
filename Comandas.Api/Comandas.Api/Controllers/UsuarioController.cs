using Comandas.Api.DTOs;
using Comandas.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Comandas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        // Variavel para simular um banco de dados em memória
        public ComandasDbContext _context { get; set; }
        // Construtor
        public UsuarioController(ComandasDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IResult GetUsuario()
        {
            //carregar usuarios do banco de dados
            var usuarios = _context.Usuarios.ToList();
            return Results.Ok(usuarios);
        }
        [HttpGet("{id}")]
        public IResult Get(int id)
        {
            var usuario = _context.Usuarios;
            if (usuario is null)
            {
                return Results.NotFound("Usuario não encontrado!");
            }
            return Results.Ok(usuario);
        }

        // POST api/<MesaController>
        [HttpPost]
        public IResult Post([FromBody] UsuarioCreatedRequest usuarioCreated)
        {
            if (usuarioCreated.Senha.Length < 6)
                return Results.BadRequest("A senha deve ter no mínimo 6 caracteres.");

            if (usuarioCreated.Nome.Length < 3)
                return Results.BadRequest("O nome deve ter no mínimo 3 caracteres.");

            if (usuarioCreated.Email.Length < 6 || !usuarioCreated.Email.Contains("@"))
                return Results.BadRequest("O email deve ser valido");
            var emailExists = _context.Usuarios
                .FirstOrDefault(u => u.Email == usuarioCreated.Email);
            if (emailExists is not null)
                return Results.BadRequest("O email já está em uso.");

            var usuario = new Usuario
            {
                Nome = usuarioCreated.Nome,
                Email = usuarioCreated.Email,
                Senha = usuarioCreated.Senha
            };
            //adicionar usuario ao banco de dados
            _context.Usuarios.Add(usuario);
            //Salvar mudanças
            _context.SaveChanges();
            return Results.Created($"/api/usuario/{usuario.Id}", usuario);
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public IResult Put(int id, [FromBody] UsuarioUpdateRequest usuarioUpdate)
        {
            var usuario = _context.Usuarios.
                FirstOrDefault(u => u.Id == id);
            if (usuario is null)
                return Results.NotFound($"Usuario do id {id} não foi encontrado!");
            //Atualizar os dados do usuario
            usuario.Nome = usuarioUpdate.Nome;
            usuario.Email = usuarioUpdate.Email;
            usuario.Senha = usuarioUpdate.Senha;

            _context.SaveChanges();
            //Retornar sem conteudo
            return Results.NoContent();

        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public IResult Delete(int id)
        {
            var usuario = _context.Usuarios.
                FirstOrDefault(u => u.Id == id);
            if (usuario is null)
                return Results.NotFound($"Usuario do id {id} não foi encontrado!");
            _context.Usuarios.Remove(usuario);
            var remove = _context.SaveChanges();
            if (remove > 0)
            {
                return Results.NoContent();
            }
            return Results.StatusCode(500);
        }

        //crir metodo para login
        [HttpPost("login")]
        public IResult Login([FromBody] LoginRequest LoginRequest)
        {
            var usuario = _context.Usuarios.
                FirstOrDefault(u => 
                u.Email == LoginRequest.Email && 
                u.Senha == LoginRequest.Senha);

            //401 - Unauthorized
            if (usuario is null)
                return Results.Unauthorized();
            //200 - OK
            return Results.Ok("Usuario autenticado");
        }
    }
}
