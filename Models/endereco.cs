using System.ComponentModel.DataAnnotations;

namespace ecommerce_db.Models
{
    public class endereco {
        [Key]
        public int id { get; set; }
        public string? cep { get; set; }

        [Required ]
        [MaxLength(11, ErrorMessage = "O campo {0} deve ter tamanho igual a {8}")]
        public string? cidade { get; set; }
        public string? bairro { get; set; }
        public string? lougadouro { get; set; }
        public string? uf { get; set; }

    }
}
