using System.ComponentModel.DataAnnotations;

namespace ecommerce_db.Models
{
    public class Endereco {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "O campo {0} é de campo obrigatório.")]
        [MaxLength(8, ErrorMessage = "O campo {0} deve ter tamanho igual a 8")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "O campo {0} é de campo obrigatório.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O campo {0} é de campo obrigatório.")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O campo {0} é de campo obrigatório.")]
        public string Lougadouro { get; set; }

        [Required(ErrorMessage = "O campo {0} é de campo obrigatório.")]
        [MaxLength(2,ErrorMessage = "O campo {0} deve ter tamanho no maximo a 2 caracter")]
        public string UF { get; set; }

        [MaxLength(50,ErrorMessage ="O campo {0} só pode ter {1}")]
        public string Referencia { get; set; }

        [Required(ErrorMessage ="O campo {0} é campo obrigatório")]
        public string Numero { get; set; }

    }
}
