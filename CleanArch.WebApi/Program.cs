using CleanArch.Ioc;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using WebApiIdentity.Services;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container.

builder.Services.AddInfrastructureSwagger();

builder.Services.AddControllers(options =>
{
    options.Filters.Add(new AuthorizeFilter());
});

//Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddControllers();

void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddInfrastructure(configuration);
    services.AddInfrastructureJwt(configuration);
}


var connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
                  options.UseSqlServer(connection));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 7;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredUniqueChars = 1;
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(optionts =>
    {
        optionts.Cookie.Name = "AspnetCore.Cookies";
        optionts.ExpireTimeSpan = TimeSpan.FromMinutes(15);
        optionts.SlidingExpiration = true;
    });

builder.Services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequiredUserAdminGerenteRoles",
        policy => policy.RequireRole("User", "Admin", "Gerente"));
});

var app = builder.Build();

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStatusCodePages();

await CriarPerfisUsuariosAsync(app);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

async Task CriarPerfisUsuariosAsync(WebApplication app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<ISeedUserRoleInitial>();
        await service.SeedRolesAsync();
        await service.SeedUserAsync();
    }
}
