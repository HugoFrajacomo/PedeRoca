using Microsoft.AspNetCore.Mvc;
using PedeRoca.Models.Entities;

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
        //----------------------------- Listar Todos - Carrinhos -------------------------- 
        //#region "Listar Carrinhos"
        //// GET: ProdutoController - ListarTodosProdutos
        //[HttpGet]
        //public IActionResult Index()
        //{
        //    List<ItemDoCarrinho> itens = 
        //    return View(this.repository.ListarTodosItensCarrinho());
        //}
        //#endregion

        //----------------------------- Listar Por ID -------------------------------------
        #region "Listar Carrinhos por ID"
        // Post: ProdutoController - Details por ID //Imformaçao por ID
        [HttpGet]
        public IActionResult DetailsCarrinho(int id)
        {
            return View(this.repository.DetailsCarrinhoID(id));
        }
        #endregion

        //----------------------------- Create - Carrinho - Compra ------------------------
        #region "Criar Carrinho - Comprar"
        // GET: ProdutoController/Create
        [HttpGet]
        public IActionResult CreateCarrinho()
        {
            return View();
        }

        // POST: ProdutoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCarrinho(Carrinho carrinho)
        {
            try
            {
                this.repository.AdicionarCarrinho(carrinho);
                return RedirectToAction(nameof(DetailsCarrinho));
            }
            catch
            {
                return View();
            }
        }
        #endregion

        //----------------------------- Create - Carrinho - AddCarrinho -------------------
        #region "Criar Carrinho - Comprar"
        // GET: ProdutoController/Create
        [HttpGet]
        public IActionResult CreateADDCarrinho()
        {
            return View();
        }

        // POST: ProdutoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateADDCarrinho(Carrinho carrinho)
        {
            try
            {
                this.repository.AdicionarCarrinho(carrinho);
                return RedirectToPage("Produto","Index");
            }
            catch
            {
                return View();
            }
        }
        #endregion

        //----------------------------- Excluir - Carrinho --------------------------------
        //#region "Excluir Carrinho"
        //// GET: ProdutoController/Delete/5 - Excluir Produto pelo ID
        //[HttpGet]
        //public IActionResult RemoverCarrinho(int id)
        //{
        //    this.repository.RemoverCarrinho(id);
        //    return RedirectToAction(nameof(CarrinhoVazio));
        //}
        //#endregion

        //----------------------------- View sem carrinho ---------------------------------
        //#region "Página sem carrinho"
        //public IActionResult CarrinhoVazio()
        //{
        //    return View();
        //}
        //#endregion
    }
}
