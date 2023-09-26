﻿using System.ComponentModel.DataAnnotations;

namespace ecommerce_db.Models
{
    public class Produto
    {
            [Key]
            public int Id { get; set; }

            [MaxLength(11, ErrorMessage = "O campo {nome} deve ter tamanho igual a {100}")]

            [MinLength(11, ErrorMessage = "O campo {nome} deve ter no mínimo {1} caracteres.")]
            public string? nome { get; set; }

            [MaxLength(11, ErrorMessage = "O campo {descricao} deve ter tamanho igual a {150}")]

            [MinLength(11, ErrorMessage = "O campo {descricao} deve ter no mínimo {15} caracteres.")]
            public string? descricao { get; set; }
            public string? categoria { get; set; }
            public float? preco { get; set; }
            public int unidadedeMedida { get; set; }
            public ICollection<ItemPedido> ItensdoPedido { get; set; } = new List<ItemPedido>();
    }
}