﻿using PedeRoca.Models.Entities.Enuns;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PedeRoca.Models.Entities
{
    public class Pessoa
    {
        [DisplayName("ID")]
        public int Id_usuario { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Mínimo de 1 e máximo de 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "CPF deve conter 11 caracteres.")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        [StringLength(15, MinimumLength = 15)]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        [DisplayName("Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNasc { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        [DisplayName("E-mail")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Máximo de 100 caracteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        [StringLength(9, MinimumLength = 9)]
        public string CEP { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        [StringLength(200, MinimumLength = 1)]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "Use a sigla com 2 caracteres")]
        [RegularExpression("^[A-Z]{2}$", ErrorMessage = "Use apenas letras maiúsculas")]
        public string UF { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        public int Numero { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 1)]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 1)]
        public string Bairro { get; set; }

        public string Complemento { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Mínimo de 6")]
        public string Senha { get; set; }
        [DisplayName("Notificação por WhatsApp")]
        public bool Notific_WP { get; set; }
        [DisplayName("Notificação por SMS")]
        public bool Notific_SMS { get; set; }
        [DisplayName("Notificação por Email")]
        public bool Notific_Email { get; set; }
        public bool Status { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        [DisplayName("Nivel de Acesso")]
        public NivelDeAcesso Tipo { get; set; }
        public Favoritos Favoritos { get; set; }



        //Construtor
        public Pessoa() 
        {
            Id_usuario = 0;
            Nome = string.Empty;
            CPF = string.Empty;
            Telefone = string.Empty;
            DataNasc = DateTime.Now;
            Email = string.Empty;
            CEP = string.Empty;
            Logradouro = string.Empty;
            UF = string.Empty;
            Numero = 0;
            Cidade = string.Empty;
            Bairro = string.Empty;
            Senha = string.Empty;
            Notific_WP = true;
            Notific_SMS = true;
            Notific_Email = true;
            Status = true;
            Tipo = NivelDeAcesso.Consumidor;
            Favoritos = new Favoritos();
        }
    }
}
