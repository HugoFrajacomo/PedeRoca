using PedeRoca.Models.Entities.Enuns;

namespace PedeRoca.Models.Entities
{
    public class LoginResultado
    {
        public bool Sucess { get; set; }
        public int Id { get; set; }
        public NivelDeAcesso Tipo { get; set; }

        public LoginResultado()
        {
            Id = 0;
            Tipo = NivelDeAcesso.Consumidor;
        }
    }
}
