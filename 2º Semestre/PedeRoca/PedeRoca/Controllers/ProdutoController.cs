using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PedeRoca.Models.Entities;
using Refit;
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

        //----------------------------- Listar Todos - Usuários -------------------------- ok
        #region "Listar Produtos"
        // GET: ProdutoController - ListarTodosProdutos
        [HttpGet]
        public IActionResult Index()
        {
            return View(this.repository.ListarTodosProdutos());
        }
        #endregion

        //----------------------------- Listar Todos - ADM ------------------------------- ok
        #region "Listar Produtos"
        // GET: ProdutoController - ListarTodosProdutos
        [HttpGet]
        public IActionResult ADMProduto()
        {
            return View(this.repository.ListarTodosProdutos());
        }
        #endregion

        //----------------------------- Listar Por ID - ADM ------------------------------ ok
        #region "Listar Produtos por ID"
        // Post: ProdutoController - Details por ID //Imformaçao por ID
        [HttpGet]
        public IActionResult ADMDetails(int id)
        {
            return View(this.repository.DetailsProdutoID(id));
        }

        #endregion

        //----------------------------- Create - ADM ------------------------------------- ok
        #region "Criar Produto"
        // GET: ProdutoController/Create
        [HttpGet]
        public IActionResult ADMCreate()
        {
            return View();
        }

        // POST: ProdutoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ADMCreate(Produto produto)
        {
            try
            {
                this.repository.InserirProduto(produto);
                return RedirectToAction(nameof(ADMProduto));
            }
            catch
            {
                return View();
            }
        }
        #endregion

        //----------------------------- Edit - ADM --------------------------------------- ok
        #region "Editar Produto"
        // GET: ProdutoController/Edit/5
        [HttpGet]
        public ActionResult ADMEdit(int id)
        {
            return View(this.repository.DetailsProdutoID(id));
        }

        // POST: ProdutoController/Edit/5 - Alterar Produto
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ADMEdit(int id, Produto produto)
        {
            try
            {
                this.repository.AlterarProduto(id, produto);
                return RedirectToAction(nameof(ADMProduto));
            }
            catch
            {
                return View();
            }
        }
        #endregion

        //----------------------------- Delete - ADM ------------------------------------- ok
        #region "Excluir Produto"
        // GET: ProdutoController/Delete/5 - Excluir Produto pelo ID
        [HttpGet]
        public IActionResult ADMDelete(int id)
        {
            this.repository.ExcluirProduto(id);
            return RedirectToAction(nameof(ADMProduto));
        }
        #endregion

        //--------------------- Colocar imagem Produto no servidor -----------------
        //#region "Imagem - Servidor"
        //private string caminhoServidor;

        //public ProdutoController(IWebHostEnvironment sistema)
        //{
        //    caminhoServidor = sistema.WebRootPath;
        //}

        //[HttpGet]
        //public IActionResult Upload()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Upload(IFormFile foto)
        //{
        //    string caminhoParaSalvarImagem = caminhoServidor + "\\Imagens\\";
        //    string novoNomeParaImagem = Guid.NewGuid().ToString() + "_" + foto.FileName;

        //    if (!Directory.Exists(caminhoParaSalvarImagem))
        //    {
        //        Directory.CreateDirectory(caminhoParaSalvarImagem);
        //    }

        //    using (var stream = System.IO.File.Create(caminhoParaSalvarImagem + novoNomeParaImagem))
        //    {
        //        foto.CopyToAsync(stream);
        //    }

        //    return RedirectToAction("upload");
        //}


        //#endregion

    }
}
