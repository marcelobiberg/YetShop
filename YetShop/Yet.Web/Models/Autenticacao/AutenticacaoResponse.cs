namespace Yet.Web.Models.Autenticacao
{
    public class AutenticacaoResponse
    {
        public string Email { get; set; } = string.Empty;
        public string AutenticacaoToken { get; set; } = string.Empty;
        public bool IsLockedOut { get; set; } = false;
        public bool IsNotAllowed { get; set; } = false;
        public bool Result { get; set; } = false;
        public bool IsAdmin { get; set; } = false;
    }
}
