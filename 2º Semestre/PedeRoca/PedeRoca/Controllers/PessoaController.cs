using Microsoft.AspNetCore.Mvc;
using PedeRoca.Models.Entities;
using PedeRoca.Models.Entities.Enuns;
using System.Drawing;

namespace PedeRoca.Controllers
{
    public class PessoaController : Controller
    {
        // 1) Criar um repositório
        private readonly Repositories.ADO.SQLServer.PessoaDAO repository;
        private readonly Services.ISessao sessao;

        // 2) Criar o construtor para o repositório
        public PessoaController(IConfiguration configuration, Services.ISessao sessao) //Passar uma configuração
        {
            //trás a chave default connection para conectar no banco
            this.repository = new Repositories.ADO.SQLServer.PessoaDAO(configuration.GetConnectionString(Configurations.AppSettings.getKeyConnectionString()));
            this.sessao = sessao;
        }

        //----------------------------- Listar Todos ADM ----------------------------------- ok
        #region "Listar todos usuário"
        // GET: PessoaController - ListarTodosProdutos
        [HttpGet]
        public IActionResult ADMPessoa()
        {
            return View(this.repository.ListarPessoas());
        }
        #endregion

        //----------------------------- Listar Por ID -------------------------------------- ok
        #region "Listar usuários por ID"
        // GET: PessoaController - Details por ID //Imformaçao por ID
        [HttpGet]
        public IActionResult ADMDetails(int id)
        {
            return View(this.repository.DetailsPessoaID(id));
        }
        #endregion

        //----------------------------- Create Usuário ------------------------------------- ok
        #region "Criar Usuário"
        // GET: PessoaController/Create
        [HttpGet]
        public IActionResult Cadastro()
        {
            return View();
        }

        // POST: PessoaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastro(Pessoa pessoa)
        {
            try
            {
                this.repository.InserirPessoaUser(pessoa);
                return RedirectToAction("Index", "Produto"); //mudar pra página login após criação do mesmo
            }
            catch
            {
                return View();
            }
        }
        #endregion

        //----------------------------- Create ADM ----------------------------------------- ok
        #region "Criar Usuário"
        // GET: PessoaController/Create
        [HttpGet]
        public IActionResult ADMCreate()
        {
            return View();
        }

        // POST: PessoaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ADMCreate(Pessoa pessoa)
        {
            try
            {
                this.repository.InserirPessoa(pessoa);
                return RedirectToAction(nameof(ADMPessoa));
            }
            catch
            {
                return View();
            }
        }
        #endregion

        //----------------------------- Edit ADM-------------------------------------------- ok
        #region "Editor Usuário"
        // GET: PessoaController/Edit/5
        [HttpGet]
        public ActionResult ADMEdit(int id)
        {
            return View(this.repository.DetailsPessoaID(id));
        }

        // POST: PessoaController/Edit/5 - Alterar Pèssoa
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ADMEdit(int id, Pessoa pessoa)
        {
            try
            {
                this.repository.AlterarPessoa(id, pessoa);
                return RedirectToAction(nameof(ADMPessoa));
            }
            catch
            {
                return View();
            }
        }
        #endregion

        //----------------------------- Delete ADM------------------------------------------ ok
        #region "Excluir Usuário"
        // GET: PessoaController/Delete/5 - Excluir Produto pelo ID
        [HttpGet]
        public IActionResult ADMDelete(int id)
        {
            this.repository.ExcluirPessoa(id);
            return RedirectToAction(nameof(ADMPessoa));
        }
        #endregion

        //----------------------------- MÉTODOS SESSÃO -------------------------------------

        #region "Método de Get e SET para o login"

        [HttpGet]
        public IActionResult Login() //Padrão é index, mas dessa vez vamos nomear como login -> página de login
        {
            //se o usuário não tiver logado retorna a View, senão retorna para a páguna de início
            return this.sessao.getTokenLogin() == null ? View() : RedirectToAction("Pessoa", "login");
            //return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Pessoa pessoa)
        {
            //com controle de sessão
            if (!string.IsNullOrEmpty(pessoa.Email) && !string.IsNullOrEmpty(pessoa.Senha))
            {
                if (this.repository.check(pessoa))
                {
                    var loginResultado = repository.GetType(pessoa);
                    this.sessao.addTokenLogin(pessoa);

                    if (loginResultado.Tipo == NivelDeAcesso.Administrador)
                        return RedirectToAction("ADMProduto", "Produto");
                    return RedirectToAction("Index", "Produto");
                }
                ModelState.AddModelError(string.Empty, "Usuário e/ou senha inválidos!");
                return View();
            }

            ViewBag.Error = "Usuário e/ou Senha inválidos";
            return View();
        }
        #endregion

        #region "Logout"
        public IActionResult Logout()
        {
            this.sessao.deleteTokenLogin();
            return RedirectToAction("index", "Produto");
        }
        #endregion

    }
}
