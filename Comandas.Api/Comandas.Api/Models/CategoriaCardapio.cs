using System.ComponentModel.DataAnnotations;

namespace Comandas.Api.Models
{
    public class CategoriaCardapio
    {

        [Key]
        public int Id { get; set; }

        public string Nome { get; set; } = default!;

        public string? Descricao { get; set; }

        public ICollection<CardapioItem>? Itens { get; set; }

    }
}

