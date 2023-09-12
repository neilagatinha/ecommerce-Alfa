using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce_db.Models
{

    public class ItemPedido
    {

        public int idPedido { get; set; }
        public int idProduto { get; set; }
        public string? descricao { get; set; }
        public int quantidade { get; set; }
        public int valorUnitario { get; set; }

        [ForeignKey("idPedido")]
        public Pedido pedido { get; set; }

        [ForeignKey("idProduto")]
        public Produto produto { get; set; }
    }
}
