using System.Threading.Tasks;

namespace Yet.Core.Interfaces
{
    /// <summary>
    /// Tasks reponsáveis por manipular os serviços de e-mail
    /// </summary>
    public interface IEmail
    {
        Task EnviarEmailAsync(string email, string assunto, string msg);
    }
}
