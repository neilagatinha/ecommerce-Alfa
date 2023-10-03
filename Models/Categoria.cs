using System.ComponentModel.DataAnnotations;

namespace ecommerce_db.Models
{
    public class Categoria {
        [Key]
        public int Id { get; set; }

        [MaxLength(100, ErrorMessage = "O campo {0} deve ter tamanho igual a {1}")]
        [MinLength(2, ErrorMessage = "O campo {0} deve ter no mínimo {1} caracteres.")]
        public string? Nome { get; set; }

        [MaxLength(100, ErrorMessage = "O campo {0} deve ter tamanho igual a {1}")]
        [MinLength(2, ErrorMessage = "O campo {0} deve ter no mínimo {1} caracteres.")]
        public string? Descricao { get; set; }
    }
}
