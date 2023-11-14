using Newtonsoft.Json;
using NuGet.Protocol.Plugins;
using PedeRoca.Models.Entities;

namespace PedeRoca.Services
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor httpContextAccessor; //cria um tempo para sessão
        private readonly string tokenSessao;

        public Sessao(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.tokenSessao = "login"; //poderia randomizar o nome para melhorar a segurança
        }

        #region  "Inicio de sessão - adiciona o token"
        public void addTokenLogin(Pessoa pessoa)
        {
            string loginTokenJson = JsonConvert.SerializeObject(pessoa);
            this.httpContextAccessor.HttpContext?.Session.SetString(this.tokenSessao, loginTokenJson);
        }
        #endregion

        #region "Informações da sessão - Pega o token"
        public Pessoa getTokenLogin() //não está usando esse verificar
        {
            string? loginTokenJson = this.httpContextAccessor.HttpContext?.Session.GetString(this.tokenSessao);
            return loginTokenJson != null ? JsonConvert.DeserializeObject<Pessoa>(loginTokenJson) : null;
        }
        #endregion

        #region "Encerrar a seção - Apaga o token"
        public void deleteTokenLogin()
        {
            this.httpContextAccessor.HttpContext?.Session.Remove(this.tokenSessao);
        }

        #endregion


    }
}
