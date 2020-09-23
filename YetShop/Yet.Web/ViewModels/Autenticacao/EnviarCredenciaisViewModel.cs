using System.ComponentModel.DataAnnotations;

namespace Yet.Web.ViewModels.Autenticacao
{
    public class EnviarCredenciaisViewModel
    {
        [Required(ErrorMessage = "O ( E-mail ) é obrigatório.")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
    }
}
