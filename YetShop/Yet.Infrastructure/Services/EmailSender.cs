using System.Threading.Tasks;
using Yet.Core.Interfaces;

namespace Yet.Infrastructure.Services
{
    /// <summary>
    /// Objeto responsável por manipular o e-mail
    /// </summary>
    public class Email : IEmail
    {
        /// <summary>
        /// Envia e-mail
        /// </summary>
        /// <param name="email">E-mail do destinatário</param>
        /// <param name="assunto">Assunto do e-mail</param>
        /// <param name="mensagem">Mensagem do e-mail</param>
        public Task EnviarEmailAsync(string email, string assunto, string mensagem)
        {
            // TODO: Colocar aqui a lógica para enviar os e-mails.
            return Task.CompletedTask;
        }
    }
}
