using System.Threading.Tasks;

namespace Yet.Core.Interfaces
{
    /// <summary>
    /// Tasks reponsáveis por manipular os serviços do Token claims
    /// </summary>
    public interface ITokenServico
    {
        Task<string> ObterTokenAsync(string userName);
    }
}
