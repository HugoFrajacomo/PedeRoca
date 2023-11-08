using System.ComponentModel.DataAnnotations;

namespace PedeRoca.Models.Entities
{
    public class Login
    {
        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Máximo de 100 caracteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 0)]
        public string Senha { get; set; }

        public Login()
        {
            Email = string.Empty;
            Senha = string.Empty;
        }
    }


}
