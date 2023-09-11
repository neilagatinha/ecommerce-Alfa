namespace ecommerce_db.Models
{
    public class Produto
    {
        public int Id { get; set; };
        public string? nome { get; set; };
        public string? descricao { get; set; };
        public string? categoria { get; set; };
        public float? preco { get; set; };
        public int unidadeMedida { get; set; };
    
    }
}