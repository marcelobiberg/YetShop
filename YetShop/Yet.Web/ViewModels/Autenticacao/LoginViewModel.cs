using System.ComponentModel.DataAnnotations;

namespace Yet.Web.ViewModels.Autenticacao
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="O ( E-mail ) é obrigatório na autenticação")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "A ( Senha ) é obrigatória na autenticação")]
        [StringLength(255, ErrorMessage = "Must be between 6 and 255 caracteres", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
