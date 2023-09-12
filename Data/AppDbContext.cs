﻿using ecommerce_db.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace ecommerce_db.Data
{
    public class AppDbContext : DbContext {

        public AppDbContext(DbContextOptions options) : base(options) { 
        }
        
        public DbSet<Pedido> Pedidos { get; set; }

        public DbSet<ItemPedido> ItensdoPedido { get; set; }

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<endereco> Enderecos { get; set; }

        public DbSet<Clientes> Cliente { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){

            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<ItemPedido>()
                .HasKey(i => new { i.IdPedido, i.IdProduto });

            modelBuilder.Entity<ItemPedido>()
                .HasOne<Produto>(P => P.ItensdoPedido)
                .WithMany(i => i.Produto)
                .HasForeignKey(i => i.IdProduto)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<ItemPedido>()
                .HasOne<Pedido>(pe => pe.ItensdoPedido)
                .WithMany(pe => pe.ItensdoPedido)
                .HasForeignKey(i => i.IdPedido)
                .OnDelete(DeleteBehavior.Cascade);



        }
      
    }
}
