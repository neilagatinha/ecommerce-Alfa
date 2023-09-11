namespace ecommerce_db.Models
{
    public class Clientes
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? email  { get; set; }

        public int telefone  { get; set; }

        public endereco? endereco { get; set; }

    }
}
