using Microsoft.AspNetCore.Mvc;
using PedeRoca.Models.Entities;

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

        // GET: PessoaController - ListarTodosProdutos
        [HttpGet]
        public IActionResult Index()
        {
            return View(this.repository.ListarPessoas());
        }

        // GET: PessoaController - Details por ID //Imformaçao por ID
        [HttpGet]
        public IActionResult Details(int idPessoa)
        {
            return View(this.repository.DetailsPessoaID(idPessoa));
        }

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

        // GET: PessoaController/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PessoaController/Edit/5 - Alterar Produto
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

        // GET: PessoaController/Delete/5 - Excluir Produto pelo ID
        [HttpGet]
        public IActionResult Delete(int id)
        {
            this.repository.ExcluirPessoa(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
