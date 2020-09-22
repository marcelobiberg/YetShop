using Refit;
using System.Threading.Tasks;
using Yet.Web.Models.Autenticacao;

namespace Yet.Web.Interfaces
{
    public interface IAutenticacaoServico
    {
        [Post("/api/Autenticacao")]
        Task<AutenticacaoResponse> Autentica(AutenticacaoRequest request);
    }
}
