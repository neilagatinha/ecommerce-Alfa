using System.ComponentModel.DataAnnotations;

namespace ecommerce_db.Models
{
    public class UnidadeDeMedida
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(20, ErrorMessage = "O campo {0} deve ter tamanho igual {1}")]
        [MinLength(2, ErrorMessage = "O campo {0} deve ter tamanho igual {1}")]
        public string Nome { get; set; }
        [MaxLength(3, ErrorMessage = "O campo {0} deve ter tamanho igual {1}")]
        [MinLength(2, ErrorMessage = "O campo {0} deve ter tamanho igual {1}")]
        public string Sigla { get; set;}

    }
}
