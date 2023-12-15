using CleanArchMvc.Domain.Account;
using Microsoft.AspNetCore.Identity;

namespace WebApiIdentity.Services;

public class SeedUserRoleInitial : ISeedUserRoleInitial
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public SeedUserRoleInitial(UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public void SeedRoles()
    {
        if(!_roleManager.RoleExistsAsync("User").Result)
        {
            IdentityRole role = new IdentityRole();
            role.Name = "User";
            role.NormalizedName = "USER";
            role.ConcurrencyStamp = Guid.NewGuid().ToString();

            IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
        }

        if (!_roleManager.RoleExistsAsync("Admin").Result)
        {
            IdentityRole role = new IdentityRole();
            role.Name = "Admin";
            role.NormalizedName = "ADMIN";
            role.ConcurrencyStamp = Guid.NewGuid().ToString();

            IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
        }

        if (!_roleManager.RoleExistsAsync("Gerente").Result)
        {
            IdentityRole role = new IdentityRole();
            role.Name = "Gerente";
            role.NormalizedName = "GERENTE";
            role.ConcurrencyStamp = Guid.NewGuid().ToString();

            IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
        }
    }

    public void SeedUsers()
    {
        if(_userManager.FindByEmailAsync("usuario@localhost") == null)
        {
            IdentityUser user = new IdentityUser();
            user.Email = "usuario@localhost";
            user.UserName = "usuario@localhost";
            user.NormalizedEmail = "USUARIO@LOCALHOST";
            user.NormalizedUserName = "USUARIO@LOCALHOST";
            user.EmailConfirmed= true;
            user.LockoutEnabled= false;
            user.SecurityStamp = Guid.NewGuid().ToString();    

            IdentityResult result = _userManager.CreateAsync(user, "Numsey#2023").Result;

            if (result.Succeeded)
            {
                _userManager.AddToRoleAsync(user, "usuario");
            }
        }

        if (_userManager.FindByEmailAsync("admin@localhost") == null)
        {
            IdentityUser user = new IdentityUser();
            user.Email = "admin@localhost";
            user.UserName = "admin@localhost";
            user.NormalizedEmail = "ADMIN@LOCALHOST";
            user.NormalizedUserName = "ADMIN@LOCALHOST";
            user.EmailConfirmed = true;
            user.LockoutEnabled = false;
            user.SecurityStamp = Guid.NewGuid().ToString();

            IdentityResult result = _userManager.CreateAsync(user, "Numsey#2023").Result;

            if (result.Succeeded)
            {
                _userManager.AddToRoleAsync(user, "admin");
            }
        }

        if (_userManager.FindByEmailAsync("gerente@localhost") == null)
        {
            IdentityUser user = new IdentityUser();
            user.Email = "gerente@localhost";
            user.UserName = "gerente@localhost";
            user.NormalizedEmail = "GERENTE@LOCALHOST";
            user.NormalizedUserName = "GERENTE@LOCALHOST";
            user.EmailConfirmed = true;
            user.LockoutEnabled = false;
            user.SecurityStamp = Guid.NewGuid().ToString();

            IdentityResult result = _userManager.CreateAsync(user, "Numsey#2023").Result;

            if (result.Succeeded)
            {
                _userManager.AddToRoleAsync(user, "gerente");
            }
        }
    }
}
