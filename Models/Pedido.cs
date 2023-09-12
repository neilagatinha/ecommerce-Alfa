using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce_db.Models
{
    public class Pedido
    {
        public int id { get; set; }
        public int IdCliente { get; set; }
        public  DateTime data  { get; set; }
        public float valorTotal { get; set; }
        public endereco? endereco { get; set; }

        public ICollection<ItemPedido> ItensdoPedido { get; set; } = new List<ItemPedido>();
        [ForeignKey("IdCliente")]
        public Clientes Cliente { get; set; }

    }
}
