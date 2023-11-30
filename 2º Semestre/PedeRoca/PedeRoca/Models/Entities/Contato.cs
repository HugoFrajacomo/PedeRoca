using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PedeRoca.Models.Entities
{
    public class Contato
    {
        [DisplayName("ID")]
        public int Id_Contato { get; set; }

        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(1000, MinimumLength = 1, ErrorMessage = "Máximo de 1000 caracteres.")]

        public string Conteudo { get; set; }
    }
}
