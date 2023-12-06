using Microsoft.AspNetCore.Mvc;

namespace PedeRoca.Controllers
{
    public class CarrinhoController : Controller
    {
        // 1) Criar um repositório
        private readonly Repositories.ADO.SQLServer.CarrinhoDAO repository;

        // 2) Criar o construtor para o repositório
        public CarrinhoController(IConfiguration configuration) //Passar uma configuração
        {
            //trás a chave default connection para conectar no banco
            this.repository = new Repositories.ADO.SQLServer.CarrinhoDAO(configuration.GetConnectionString(Configurations.AppSettings.getKeyConnectionString()));
        }

        //----------------------------- Listar Por ID - ADM --------------------------
        #region "Listar Carrinho por ID"
        // Post: ProdutoController - Details por ID //Imformaçao por ID
        [HttpGet]
        public IActionResult CarrinhoDeCompras(int idUsuario)
        {
            if (idUsuario != 0)
            {
                return View(this.repository.Carrinho(idUsuario));
            }
            else
            {
                return RedirectToAction("CarrioVazio");
            }
        }
        #endregion

        //----------------------------- Listar Por ID - ADM --------------------------
        #region "CarrinhoVazio"

        public IActionResult CarrioVazio()
        {
            return View();
        }

        #endregion

        //----------------------------- Listar items do Carrinho ---------------------
        #region "Listar Produtos"
        // GET: ProdutoController - ListarTodosProdutos
        [HttpGet]
        public IActionResult Carrinho(int id)
        {
            return View(this.repository.ListarTodosProdutos(id));
        }
        #endregion
    }
}
