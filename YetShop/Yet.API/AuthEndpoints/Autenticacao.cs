using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;
using Yet.Core.Interfaces;
using Yet.Infrastructure.Identity;

namespace Yet.API.AuthEndpoints
{
    public class Autenticacao : BaseAsyncEndpoint<AutenticacaoRequest, AutenticacaoResponse>
    {
        #region Campos
        private readonly SignInManager<UsuarioApp> _signInManager;
        private readonly UserManager<UsuarioApp> _userManager;
        private readonly ITokenServico _tokenServico;
        #endregion

        #region Ctor
        public Autenticacao(SignInManager<UsuarioApp> signInManager,
            ITokenServico tokenService,
            UserManager<UsuarioApp> userManager)
        {
            _signInManager = signInManager;
            _tokenServico = tokenService;
            _userManager = userManager;
        }
        #endregion

        #region Métodos
        [HttpPost("api/Autenticacao")]
        [SwaggerOperation(
            Summary = "Autenticação do usuário",
            Description = "Valida credenciais do usuário",
            OperationId = "auth.Autenticacao",
            Tags = new[] { "AuthEndpoints" })
        ]
        public override async Task<ActionResult<AutenticacaoResponse>> HandleAsync(AutenticacaoRequest request,
            CancellationToken cancellationToken)
        {
            // Instancia o objeto  response ( AutenticacaoResponse )
            var response = new AutenticacaoResponse(request.CorrelacaoId());

            // Busca o usuário por e-mail
            var user = await _userManager.FindByEmailAsync(request.Email);

            // Valida o usuário e loga no sistema
            var result = await _signInManager.PasswordSignInAsync(user, request.Senha, false, lockoutOnFailure: true);

            // . . Se nao encontrou usuário retorna objeto response
            if (!result.Succeeded)
            {
                // Obtém um valor que indica se o usuário associado está bloqueado e não pode ser validado.
                response.IsLockedOut = result.IsLockedOut;
                // Valida o usuário que está tentando fazer login não tem permissão para fazer login
                response.IsNotAllowed = result.IsNotAllowed;
            }
            else
            {
                // Dados do usuário
                response.Email = request.Email;
                response.AutenticacaoToken = await _tokenServico.ObterTokenAsync(request.Email);
            }

            // Result = false por padrão
            response.Result = result.Succeeded;

            // . . Retorna o obejto response populados com as credenciais do usuário e permissões
            return response;
        }
        #endregion
    }
}
