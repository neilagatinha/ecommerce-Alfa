using System.ComponentModel.DataAnnotations;

namespace ecommerce_db.Models
{
    public class Clientes
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(11, ErrorMessage = "O campo {0} deve ter tamanho igual a {1}")]
        [MinLength(11, ErrorMessage = "O campo {0} deve ter no mínimo {1} caracteres.")]
        public string? Name { get; set; }

        [EmailAddress(ErrorMessage = "O campo {0} deve conter um endereço de e-mail válido")]
        public string? email  { get; set; }

        [MaxLength(11, ErrorMessage = "O campo {0} deve ter no mínimo {1} caracteres.")]
        public int telefone  { get; set; }

        public endereco? endereco { get; set; }

    }
}
