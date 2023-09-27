using System.ComponentModel.DataAnnotations;

namespace ecommerce_db.Models
{
    public class endereco {
        [Key]
        public int id { get; set; }


        [Required(ErrorMessage = "O campo {0} é de campo obrigatório.")]
        [MaxLength(8, ErrorMessage = "O campo {0} deve ter tamanho igual a 8")]
        public string? cep { get; set; }

        [Required(ErrorMessage = "O campo {0} é de campo obrigatório.")]
        public string? cidade { get; set; }

        [Required(ErrorMessage = "O campo {0} é de campo obrigatório.")]
        public string? bairro { get; set; }

        [Required(ErrorMessage = "O campo {0} é de campo obrigatório.")]
        public string? lougadouro { get; set; }

        [Required(ErrorMessage = "O campo {0} é de campo obrigatório.")]
        public string? uf { get; set; }

    }
}
