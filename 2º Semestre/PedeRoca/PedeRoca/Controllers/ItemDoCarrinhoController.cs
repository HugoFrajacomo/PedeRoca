using AngleSharp.Html;
using Microsoft.AspNetCore.Mvc;
using PedeRoca.Models.Entities;

namespace PedeRoca.Controllers
{
    public class ItemDoCarrinhoController : Controller
    {
        // 1) Criar um repositório
        private readonly Repositories.ADO.SQLServer.ItemDoCarrinhoDAO repository;

        // 2) Criar o construtor para o repositório
        public ItemDoCarrinhoController(IConfiguration configuration) //Passar uma configuração
        {
            //trás a chave default connection para conectar no banco
            this.repository = new Repositories.ADO.SQLServer.ItemDoCarrinhoDAO(configuration.GetConnectionString(Configurations.AppSettings.getKeyConnectionString()));
        }
        //------------------- Listar Items Carrinho -------------------------- 
        #region
        [HttpGet]
        public IActionResult CarrinhoDeCompras()
        {
            return View(this.repository.ListarTodosItensCarrinho());
        }
        #endregion


        //------------------- Detail Items Carrinho -------------------------- ok
        #region "Detail"
        // GET: ProdutoController - Detail Item Carrinho
        [HttpGet]
        public IActionResult DetailItemCarrinho(int id)
        {
            return View(this.repository.DetailsItemID(id));
        }
        #endregion

        //------------------- Create - ADM ----------------------------------- Testar
        #region "Adicionar itemCarrinho"

        // GET: ProdutoController/Create
        [HttpGet]
        public IActionResult AdicionarItemAoCarrinho()
        {
            return View();
        }

        // POST: ProdutoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AdicionarItemAoCarrinho(ItemDoCarrinho item)
        {
            try
            {
                this.repository.AdicionarItemAoCarrinho(item);
                return RedirectToPage("Index","Produto");
            }
            catch
            {
                return View();
            }
        }

        #endregion

        //------------------- Alter Quantidade - ADM ------------------------- ok
        #region "Editar Produto"
        // GET: ProdutoController/Edit/5
        [HttpGet]
        public ActionResult EditarItemCarrinho(int id)
        {
            return View(this.repository.DetailsItemID(id));
        }

        // POST: ProdutoController/Edit/5 - Alterar Produto
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditarItemCarrinho(int id, ItemDoCarrinho item)
        {
            try
            {
                this.repository.AtualizarQuantidadeItemNoCarrinho(id, item);
                return RedirectToAction(nameof(CarrinhoDeCompras));
            }
            catch
            {
                return View();
            }
        }
        #endregion

        //------------------- Excluir Item ----------------------------------- ok
        #region "Excluir item"
        // GET: ProdutoController/Delete/5 - Excluir Produto pelo ID
        [HttpGet]
        public IActionResult ExcluirItem(int id)
        {
            this.repository.RemoverItemDoCarrinho(id);
            return RedirectToAction(nameof(CarrinhoDeCompras));
        }
        #endregion
    }
}
