using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApiIdentity.Models;

namespace WebApiIdentity.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, 
            SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        [HttpGet("user")]
        public IActionResult GetCurrentUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userId = _userManager.GetUserId(User);
                var user = _userManager.Users.FirstOrDefault(u => u.Id == userId);
                return Ok(new { Email = user.Email });
            }

            return BadRequest(new { Message = "Usuário não autenticado" });
        } 

        [HttpPost]

        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            if(ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = registerModel.Email,
                    Email = registerModel.Email
                };

                var result = await _userManager.CreateAsync(user, registerModel.Password);

                if(result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);                    
                }

                var errors = result.Errors.Select(error => error.Description);
                return BadRequest(new { Errors = errors });
            }
            
            return BadRequest(new { Errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)) });
        }

        [HttpPost]

        public async Task<IActionResult> Login (LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginModel.Email, 
                    loginModel.Password, loginModel.RemeberMe, false);

                if (result.Succeeded)
                {
                    return Ok(new { Message = "Login bem-sucedido" });
                }

                if (result.IsLockedOut)
                {
                    
                    return BadRequest(new { Message = "Conta bloqueada devido a várias tentativas de login malsucedidas. Tente novamente mais tarde." });
                }

                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = "", RememberMe = loginModel.RememberMe });
                }                
                ModelState.AddModelError(string.Empty, "Login inválido");
                return BadRequest(new { Message = "Credenciais inválidas" });
            }
            return BadRequest(ModelState);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok(new { Message = "Logout bem-sucedido" });
        }
    }
}
