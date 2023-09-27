using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce_db.Models
{

    public class ItemPedido
    {

        public int idPedido { get; set; }
        public int idProduto { get; set; }


        [Required(ErrorMessage = "O campo {0} é preenchimento obrgatório.")]
        public string? descricao { get; set; }


        [Required(ErrorMessage = "O campo {0} é preenchimento obrgatório.")]
        public int quantidade { get; set; }
   

        [Required(ErrorMessage = "O campo {0} é preenchimento obrgatório.")]
        public int valorUnitario { get; set; }


        [ForeignKey("idPedido")]
        public Pedido pedido { get; set; }

        [ForeignKey("idProduto")]
        public Produto produto { get; set; }
    }
}
