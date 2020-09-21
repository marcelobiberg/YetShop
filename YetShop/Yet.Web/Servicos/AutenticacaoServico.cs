using Microsoft.Extensions.Configuration;
using Refit;
using System.Threading.Tasks;
using Yet.Web.Interfaces;
using Yet.Web.Models.Autenticacao;

namespace Yet.Web.Servicos
{
    public class AutenticacaoServico : IAutenticacaoServico
    {
        #region Campos
        private readonly IConfiguration _configuration;
        private readonly string _baseUrlApi;
        #endregion

        #region Ctor
        public AutenticacaoServico(IConfiguration configuration)
        {
            _configuration = configuration;
            _baseUrlApi = _configuration["BaseUrls:apiBase"];
        }
        #endregion

        #region Método
        public Task<AutenticacaoResponse> Autentica(AutenticacaoRequest request)
        {
            var autenticacaoClient = RestService
                .For<IAutenticacaoServico>(_baseUrlApi);

            var autentica = autenticacaoClient.Autentica(new AutenticacaoRequest
            {
                Email = request.Email,
                Senha = request.Senha
            });

            return autentica;
        } 
        #endregion
    }
}
