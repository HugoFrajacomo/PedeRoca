﻿using PedeRoca.Models.Entities.Enuns;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PedeRoca.Models.Entities
{
    public class Produto
    {
        [DisplayName("ID")]
        public int Id_produtos { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Mínimo de 1 e máximo de 50 caracteres.")]
        public string Nome { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 1, ErrorMessage = "Mínimo de 1 e máximo de 150 caracteres.")]
        public string Descricao { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 1, ErrorMessage = "Mínimo de 1 e máximo de 200 caracteres.")]
        public string Imagem { get; set; }

        [Required]
        [DisplayName("Qtd em Estoque")]
        public int QtdEstoque { get; set; }

        [Required]
        [DisplayName("Preço Unitário")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecoUnitario { get; set; }

        [Required]
        public UnidadeProdutos Unidade { get; set; }

        [Required]
        [DisplayName("Categoria")]
        public TiposProdutos Tipo { get; set; }

        public Boolean Ativo { get; set; }

        public Produto()
        {
            Id_produtos = 0;
            Nome = string.Empty;
            Descricao = string.Empty;
            Imagem = string.Empty;
            QtdEstoque = 0;
            PrecoUnitario = 0;
            Unidade = 0;
            Tipo = 0;
            Ativo = false;
        }
    }
}
