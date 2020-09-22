using Ardalis.ApiEndpoints;
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
        private readonly ITokenServico _tokenServico;
        #endregion

        #region Ctor
        public Autenticacao(SignInManager<UsuarioApp> signInManager,
            ITokenServico tokenService)
        {
            _signInManager = signInManager;
            _tokenServico = tokenService;
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
            // Instancia o objeto ( AutenticacaoResponse )
            var response = new AutenticacaoResponse(request.CorrelacaoId());

            // Valida o usuário e loga no sistema
            var result = await _signInManager.PasswordSignInAsync(request.Usuario, request.Senha, false, true);

            // popula a objeto response com o resultado da validação do usuário ( true/false )
            response.Result = result.Succeeded;

            // . . Se nao encontrou usuário retorna objeto response com Result = false
            if (!result.Succeeded) return response;

            // Popula o objeto ( AutenticacaoResponse )
            response.Result = result.Succeeded;
            response.IsLockedOut = result.IsLockedOut;
            response.IsNotAllowed = result.IsNotAllowed;
            response.Usuario = request.Usuario;
            response.AutenticacaoToken = await _tokenServico.ObterTokenAsync(request.Usuario);

            return response;
        }
        #endregion
    }
}
