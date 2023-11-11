using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PedeRoca.Models.Entities;
using System.Configuration;

namespace PedeRoca.Controllers
{
    public class ProdutoController : Controller
    {
        // 1) Criar um repositório
        private readonly Repositories.ADO.SQLServer.ProdutoDAO repository;

        // 2) Criar o construtor para o repositório
        public ProdutoController(IConfiguration configuration) //Passar uma configuração
        {
            //trás a chave default connection para conectar no banco
            this.repository = new Repositories.ADO.SQLServer.ProdutoDAO(configuration.GetConnectionString(Configurations.AppSettings.getKeyConnectionString()));
        }

        //----------------------------- Listar Todos -------------------------------
        #region "Listar Produtos"
        // GET: ProdutoController - ListarTodosProdutos
        [HttpGet]
        public IActionResult Index()
        {
            return View(this.repository.ListarTodosProdutos());
        }
        #endregion

        //----------------------------- Listar Por ID ------------------------------
        #region "Listar Produtos por ID"
        // Post: ProdutoController - Details por ID //Imformaçao por ID
        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(this.repository.DetailsProdutoID(id));
        }


        //----------------------------- Listar Por ID ------------------------------
        #endregion

        //----------------------------- Create -------------------------------------
        #region "Criar Produto"
        // GET: ProdutoController/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProdutoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Produto produto)
        {
            try
            {
                this.repository.InserirProduto(produto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        #endregion

        //----------------------------- Edit ---------------------------------------
        #region "Editar Produto"
        // GET: ProdutoController/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(this.repository.DetailsProdutoID(id));
        }

        // POST: ProdutoController/Edit/5 - Alterar Produto
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Produto produto)
        {
            try
            {
                this.repository.AlterarProduto(id, produto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        #endregion

        //----------------------------- Delete -------------------------------------
        #region "Excluir Produto"
        // GET: ProdutoController/Delete/5 - Excluir Produto pelo ID
        [HttpGet]
        public IActionResult Delete(int id)
        {
            this.repository.ExcluirProduto(id);
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
