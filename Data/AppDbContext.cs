using ecommerce_db.Models;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_db.Data
{
    public class AppDbContext : DbContext {

        public AppDbContext(DbContextOptions options) : base(options) { 
        }
        public DbSet<Pedido> pedidos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);

        }

    }
}
