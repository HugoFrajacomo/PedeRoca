using Microsoft.AspNetCore.Mvc;
using PedeRoca.Models.Entities;

namespace PedeRoca.Controllers
{
    public class SobreController : Controller
    {
        // 1) Criar um repositório
        private readonly Repositories.ADO.SQLServer.SobreDAO repository;

        // 2) Criar o construtor para o repositório
        public SobreController(IConfiguration configuration) //Passar uma configuração
        {
            //trás a chave default connection para conectar no banco
            this.repository = new Repositories.ADO.SQLServer.SobreDAO(configuration.GetConnectionString(Configurations.AppSettings.getKeyConnectionString()));
        }

        //----------------------------- Listar Todos - ADM -------------------------- ok
        #region "Listar Menssagens"
        [HttpGet]
        public IActionResult ADMMenssagens()
        {
            return View(this.repository.ListarTodosMensagens());
        }
        #endregion

        //----------------------------- Listar Por ID - ADM ------------------------------ ok
        #region "Listar Produtos por ID"
        // Post: ProdutoController - Details por ID //Imformaçao por ID
        [HttpGet]
        public IActionResult ADMDetails(int id)
        {
            return View(this.repository.DetailsMenssagemID(id));
        }
        #endregion

        //----------------------------- Create ------------------------------------- ok
        #region "Criar Mensagens"
        // GET: ProdutoController/Create
        [HttpGet]
        public IActionResult index()
        {
            return View();
        }

        // POST: ProdutoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult index(Contato contato)
        {
            try
            {
                this.repository.InserirMenssagem(contato);
                return RedirectToAction(nameof(Index));
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
            this.repository.ExcluirMenssagem(id);
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
