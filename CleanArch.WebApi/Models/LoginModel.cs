using System.ComponentModel.DataAnnotations;

namespace CleanArchMvc.WebApi.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email is requerid")]
        [EmailAddress(ErrorMessage = "Invalid Format Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is requerid")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
