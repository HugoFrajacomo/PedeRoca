using Microsoft.AspNetCore.Mvc;
using PedeRoca.Integracao;
using PedeRoca.Models.Entities;
using System.Drawing;

namespace PedeRoca.Controllers
{
    public class PessoaController : Controller
    {
        // 1) Criar um repositório
        private readonly Repositories.ADO.SQLServer.PessoaDAO repository;

        // 2) Criar o construtor para o repositório
        public PessoaController(IConfiguration configuration) //Passar uma configuração
        {
            //trás a chave default connection para conectar no banco
            this.repository = new Repositories.ADO.SQLServer.PessoaDAO(configuration.GetConnectionString(Configurations.AppSettings.getKeyConnectionString()));
        }

        //----------------------------- Listar Todos ------------------------------- ok
        #region "Listar todos usuário"
        // GET: PessoaController - ListarTodosProdutos
        [HttpGet]
        public IActionResult Index()
        {
            return View(this.repository.ListarPessoas());
        }
        #endregion

        //----------------------------- Listar Por ID ------------------------------ ok
        #region "Listar usuários por ID"
        // GET: PessoaController - Details por ID //Imformaçao por ID
        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(this.repository.DetailsPessoaID(id));
        }
        #endregion

        //----------------------------- Create ------------------------------------- ok
        #region "Criar Usuário"
        // GET: PessoaController/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: PessoaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pessoa pessoa)
        {
            try
            {
                this.repository.InserirPessoa(pessoa);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        #endregion

        //----------------------------- Edit --------------------------------------- * verificar
        #region "Editor Usuário"
        // GET: PessoaController/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(this.repository.DetailsPessoaID(id));
        }

        // POST: PessoaController/Edit/5 - Alterar Pèssoa
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Pessoa pessoa)
        {
            try
            {
                this.repository.AlterarPessoa(id, pessoa);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        #endregion

        //----------------------------- Delete ------------------------------------- ok
        #region "Excluir Usuário"
        // GET: PessoaController/Delete/5 - Excluir Produto pelo ID
        [HttpGet]
        public IActionResult Delete(int id)
        {
            this.repository.ExcluirPessoa(id);
            return RedirectToAction(nameof(Index));
        }
        #endregion

    }
}
