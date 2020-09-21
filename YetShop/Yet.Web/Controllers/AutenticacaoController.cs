using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
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
        #endregion

        #region Ctor
        public AutenticacaoController(IAutenticacaoServico autenticacaoServico,
            ILogger<ICatalogoServico> logger,
            IConfiguration configuration)
        {
            _autenticacaoServico = autenticacaoServico;
            _logger = logger;
        }
        #endregion

        #region Métodos
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<LoginViewModel>> Login(LoginViewModel vm)
        {
            // Valida o model de login
            if (!ModelState.IsValid) return vm;

            _logger.LogInformation("Autenticando usuário na API . . .");
            var response = await _autenticacaoServico.Autentica(new AutenticacaoRequest
            {
                Email = vm.Email,
                Senha = vm.Senha
            });

            if (!response.Result)
            {
                ModelState.AddModelError(string.Empty, "E-mail e/ou senha incorretos");
                return vm;
            }

            // Validação para o administrativo vai aqui
            //if (response.IsAdmin)
            //{
                    //Do something
            //}


            return RedirectToAction("Dashboard");
        }
        #endregion
    }
}
