﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ecommerce_db.Data;

#nullable disable

namespace ecommerce_db.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231004185155_v300")]
    partial class v300
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ecommerce_db.Models.Clientes", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("enderecoid")
                        .HasColumnType("int");

                    b.Property<string>("telefone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.HasKey("Id");

                    b.HasIndex("enderecoid");

                    b.ToTable("cliente");
                });

            modelBuilder.Entity("ecommerce_db.Models.ItemPedido", b =>
                {
                    b.Property<int>("idPedido")
                        .HasColumnType("int");

                    b.Property<int>("idProduto")
                        .HasColumnType("int");

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("quantidade")
                        .HasColumnType("int");

                    b.Property<int>("valorUnitario")
                        .HasColumnType("int");

                    b.HasKey("idPedido", "idProduto");

                    b.HasIndex("idProduto");

                    b.ToTable("ItensdoPedido");
                });

            modelBuilder.Entity("ecommerce_db.Models.Pedido", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<DateTime>("data")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("enderecoid")
                        .HasColumnType("int");

                    b.Property<float>("valorTotal")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.HasIndex("IdCliente");

                    b.HasIndex("enderecoid");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("ecommerce_db.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("categoria")
                        .HasColumnType("longtext");

                    b.Property<string>("descricao")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("nome")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<float?>("preco")
                        .HasColumnType("float");

                    b.Property<int>("unidadedeMedida")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("ecommerce_db.Models.endereco", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("bairro")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("cep")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("varchar(8)");

                    b.Property<string>("cidade")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("lougadouro")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("uf")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("ecommerce_db.Models.Clientes", b =>
                {
                    b.HasOne("ecommerce_db.Models.endereco", "endereco")
                        .WithMany()
                        .HasForeignKey("enderecoid");

                    b.Navigation("endereco");
                });

            modelBuilder.Entity("ecommerce_db.Models.ItemPedido", b =>
                {
                    b.HasOne("ecommerce_db.Models.Pedido", "pedido")
                        .WithMany("ItensdoPedido")
                        .HasForeignKey("idPedido")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ecommerce_db.Models.Produto", "produto")
                        .WithMany("ItensdoPedido")
                        .HasForeignKey("idProduto")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("pedido");

                    b.Navigation("produto");
                });

            modelBuilder.Entity("ecommerce_db.Models.Pedido", b =>
                {
                    b.HasOne("ecommerce_db.Models.Clientes", "Clientes")
                        .WithMany()
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ecommerce_db.Models.endereco", "endereco")
                        .WithMany()
                        .HasForeignKey("enderecoid");

                    b.Navigation("Clientes");

                    b.Navigation("endereco");
                });

            modelBuilder.Entity("ecommerce_db.Models.Pedido", b =>
                {
                    b.Navigation("ItensdoPedido");
                });

            modelBuilder.Entity("ecommerce_db.Models.Produto", b =>
                {
                    b.Navigation("ItensdoPedido");
                });
#pragma warning restore 612, 618
        }
    }
}
