using PedeRoca.Models.Entities;

namespace PedeRoca.Services
{
    public interface ISessao
    {
        void addTokenLogin(Pessoa pessoa);

        Pessoa getTokenLogin();

        void deleteTokenLogin();
    }
}
