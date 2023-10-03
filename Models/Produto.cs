using System.ComponentModel.DataAnnotations;

namespace ecommerce_db.Models
{
    public class Produto
    {
            [Key]
            public int Id { get; set; }

            [MaxLength(100, ErrorMessage = "O campo {0} deve ter tamanho igual a {1}")]

            [MinLength(1, ErrorMessage = "O campo {0} deve ter no mínimo {1} caracteres.")]
            public string? nome { get; set; }

            [MaxLength(100, ErrorMessage = "O campo {0} deve ter tamanho igual a {1}")]

            [MinLength(1, ErrorMessage = "O campo {0} deve ter no mínimo {1} caracteres.")]
            public string? descricao { get; set; }
            public string? categoria { get; set; }
            public float? preco { get; set; }
            public int unidadedeMedida { get; set; }
            public ICollection<ItemPedido> ItensdoPedido { get; set; } = new List<ItemPedido>();
    }
}