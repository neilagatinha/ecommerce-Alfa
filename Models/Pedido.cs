using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce_db.Models
{
    public class Pedido
    {
        [Key]
        public int id { get; set; }
        public int IdCliente { get; set; }

        [DataType(DataType.Date, ErrorMessage = "O campo {0} deve ter uma data válida")]
        public  DateTime data  { get; set; }

        public float valorTotal { get; set; }
        public Endereco? endereco { get; set; }
      
        public ICollection<ItemPedido> ItensdoPedido { get; set; } = new List<ItemPedido>();
        [ForeignKey("IdCliente")] 
        public Cliente Clientes { get; set; }
    }
}
