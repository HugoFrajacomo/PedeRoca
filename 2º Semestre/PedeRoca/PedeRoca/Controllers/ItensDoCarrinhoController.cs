using Microsoft.AspNetCore.Mvc;

namespace PedeRoca.Controllers
{
    public class ItensDoCarrinhoController : Controller
    {

        // 1) Criar um repositório
        private readonly Repositories.ADO.SQLServer.ItemDoCarrinhoDAO repository;

        // 2) Criar o construtor para o repositório
        public ItensDoCarrinhoController(IConfiguration configuration) //Passar uma configuração
        {
            //trás a chave default connection para conectar no banco
            this.repository = new Repositories.ADO.SQLServer.ItemDoCarrinhoDAO(configuration.GetConnectionString(Configurations.AppSettings.getKeyConnectionString()));
        }

        // GET: ProdutoController - ListarTodosProdutos
        [HttpGet]
        public IActionResult Index()
        {
            return View(this.repository.ListarTodosItens());
        }

        
    }
}
