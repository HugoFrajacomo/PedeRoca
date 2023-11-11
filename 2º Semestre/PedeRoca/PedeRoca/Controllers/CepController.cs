using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PedeRoca.Integracao.Interfaces;
using PedeRoca.Integracao.Response;

namespace PedeRoca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CepController : ControllerBase
    {
        private readonly IViaCepIntegracao _viaCepIntegracao;
        public CepController(IViaCepIntegracao viaCepIntegracao) 
        {
            _viaCepIntegracao = viaCepIntegracao;
        }


        [HttpGet("{cep}")]
        public async Task<ActionResult<ViaCepResponse>> ListarDadosEndereco(string cep)
        {
            var responseData = await _viaCepIntegracao.ObterDadosViaCep(cep);

            if (responseData == null)
            {
                return BadRequest("CEP não encontrado!");
            }

            return Ok(responseData);
        }
    }
}
