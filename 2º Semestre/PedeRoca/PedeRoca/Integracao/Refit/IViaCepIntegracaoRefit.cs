using PedeRoca.Integracao.Response;
using Refit;

namespace PedeRoca.Integracao.Refit
{
    public interface IViaCepIntegracaoRefit
    {
        [Get("/ws/{cep}/json")]
        Task<ApiResponse<ViaCepResponse>> ObterDadosViaCEP(string cep);
    }
}
