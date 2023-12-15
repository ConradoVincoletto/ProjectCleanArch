using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace CleanArchMvc.WebApi.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email is requerid")]
        [EmailAddress(ErrorMessage = "Invalid Format Email")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is requerid")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        public string ReturnUrl { get; set; } = string.Empty;
    }
}
