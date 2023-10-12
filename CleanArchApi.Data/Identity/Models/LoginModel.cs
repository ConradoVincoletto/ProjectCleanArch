using System.ComponentModel.DataAnnotations;

namespace WebApiIdentity.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "O e-mail é obrigatório")]
        [EmailAddress(ErrorMessage ="E-mail inválido")]
        public string? Email { get; set; }


        [Required(ErrorMessage ="Senha é obrigatório")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        
        [Display(Name = "Lembrar-me")]       

        public bool RememberMe { get; set; }
    }
}
