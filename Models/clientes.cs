using System.ComponentModel.DataAnnotations;

namespace ecommerce_db.Models
{
    public class Clientes
    {
        [Key]
        public int? Id { get; set; }

        [MaxLength(100, ErrorMessage = "O campo {0} deve ter tamanho igual a {1}")]
        [MinLength(11, ErrorMessage = "O campo {0} deve ter no mínimo {1} caracteres.")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "O campo {0} deve conter um endereço de e-mail válido")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string email  { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int telefone  { get; set; }

        public endereco? endereco { get; set; }

    }
}
