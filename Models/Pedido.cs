using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce_db.Models
{
    public class Pedido
    {
        [Key]
        public int id { get; set; }
        public int IdCliente { get; set; }
        public  DateTime data  { get; set; }

        [DataType(DataType.Date, ErrorMessage = "O campo {0} deve ter uma data válida")]
        public float valorTotal { get; set; }
        public endereco? endereco { get; set; }
      
        public ICollection<ItemPedido> ItensdoPedido { get; set; } = new List<ItemPedido>();
        [ForeignKey("IdCliente")] 
        public Clientes Clientes { get; set; }
    }
}
