using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApiIdentity.Models;

namespace WebApiIdentity.Controllers
{
    [Authorize]
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

        //[Authorize(Roles = "Admin")]
        [Authorize(Policy = "RequiredUserAdminGerenteRoles")]
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
        [AllowAnonymous]
        [HttpPost("register")]
        
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
            }

            return Ok("Usuario criado com sucesso");
        }

        [Authorize]
        [HttpPost("login")]

        public async Task<IActionResult> Login (LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginModel.Email, 
                    loginModel.Password, loginModel.RememberMe, false);

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

        [AllowAnonymous]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok(new { Message = "Logout bem-sucedido" });
        }
    }
}
