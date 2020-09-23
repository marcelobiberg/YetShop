using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Yet.Web.Constantes;
using Yet.Web.Interfaces;
using Yet.Web.Models.Autenticacao;
using Yet.Web.ViewModels.Autenticacao;

namespace Yet.Web.Controllers
{
    public class AutenticacaoController : Controller
    {
        #region Campos
        private readonly IAutenticacaoServico _autenticacaoServico;
        private ILogger<ICatalogoServico> _logger;
        private ILocalStorageServico _localStorageServico;
        #endregion

        #region Ctor
        public AutenticacaoController(IAutenticacaoServico autenticacaoServico,
            ILogger<ICatalogoServico> logger,
            IConfiguration configuration,
            ILocalStorageServico localStorageServico)
        {
            _autenticacaoServico = autenticacaoServico;
            _logger = logger;
            _localStorageServico = localStorageServico;
        }
        #endregion

        #region Métodos
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<LoginViewModel>> Login(LoginViewModel vm, string returnUrl = null)
        {

            // Valida o model de login
            if (!ModelState.IsValid) return View(vm);

            // . . Autenticando usuário
            _logger.LogInformation("Autenticando usuário na API . . .");
            var response = await _autenticacaoServico.Autentica(new AutenticacaoRequest
            {
                Email = vm.Email,
                Senha = vm.Senha
            });

            // . . Se tudo Ok redireciona para a área do cliente no dashboard com infos do objeto response
            if (response.Result)
            {
                // Salva localmente o objeto AutenticacaoReponse
                _localStorageServico.CacheAutenticacaoResponseLocalAsync(BancoLocal.AUTENTICACAO_KEY, response);

                 if (!string.IsNullOrEmpty(returnUrl)) return LocalRedirect(returnUrl);

                // TODO: Colocar aqui objeto com infos do cadastro
                return RedirectToAction("Dashboard", "AreaCliente");
            }

            // Validação para o administrativo vai aqui
            //if (response.IsAdmin)
            //{
            //Do something
            //}

            // Se o usuário que está tentando fazer login está bloqueado
            if (response.IsLockedOut)
            {
                //  . . Redireciona para a página de bloqueio
                return RedirectToAction("Bloqueado");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "E-mail e/ou senha incorretos");
                return View(vm);
            }
        }

        [HttpGet]
        public ActionResult Bloqueado()
        {
            return View();
        }

        [HttpGet("EnviarCredenciais")]
        public ActionResult EnviarCredenciaisAsync()
        {
            //Enviar e-mail com as credencias do usuário
            return View();
        }

        [HttpPost("EnviarCredenciais")]
        public async Task<ActionResult> EnviarCredenciaisAsync(EnviarCredenciaisViewModel vm)
        {
            //Enviar e-mail com as credencias do usuário
            return View();
        }
        #endregion
    }
}
