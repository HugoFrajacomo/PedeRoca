using PedeRoca.Models.Entities.Enuns;
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
        [StringLength(11, MinimumLength = 11, ErrorMessage = "CPF deve conter 11 caracteres.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Apenas números são permitidos.")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        [StringLength(11, MinimumLength = 1, ErrorMessage = "Máximo de 11 caracteres.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Apenas números são permitidos.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        [DataType(DataType.Date)]
        public DateTime DataNasc { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Máximo de 100 caracteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        [StringLength(8, MinimumLength = 8)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Apenas números são permitidos.")]
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

        #region "Mascara CPF"
        public string FormatarCPF()
        {
            if (string.IsNullOrEmpty(CPF))
            {
                return CPF;
            }
            return Convert.ToUInt64(CPF).ToString(@"000\.000\.000\-00");
        }
        #endregion
        #region "Mascara Telefone"
        public string FormatarTelefone()
        {
            if (string.IsNullOrEmpty(Telefone))
            {
                return Telefone;
            }

            // Adiciona a máscara ao telefone (DDDCelular: (##) #####-####)
            return Convert.ToUInt64(Telefone).ToString(@"(##) #####-####");
        }
        #endregion
        #region "Mascara CEP"
        public string FormatarCEP()
        {
            if (string.IsNullOrEmpty(CEP))
            {
                return CEP;
            }

            // Adiciona a máscara ao CEP (#####-###)
            return Convert.ToUInt64(CEP).ToString(@"#####-###");
        }
        #endregion
    }
}
