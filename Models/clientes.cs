using System.ComponentModel.DataAnnotations;

namespace ecommerce_db.Models
{
    public class Clientes
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(11, ErrorMessage = "O campo {Name} deve ter tamanho igual a {100}")]
        [MinLength(11, ErrorMessage = "O campo {Name} deve ter no mínimo {15} caracteres.")]
        public string? Name { get; set; }

        [EmailAddress(ErrorMessage = "O campo {Nome} deve conter um endereço de e-mail válido")]
        public string? email  { get; set; }
        [MinLength(11, ErrorMessage = "O campo {telefone} deve ter no mínimo {9} caracteres.")]
        public int telefone  { get; set; }

        public endereco? endereco { get; set; }

    }
}
