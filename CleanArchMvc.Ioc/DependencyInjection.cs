using CleanArchMcv.Application.Interfaces;
using CleanArchMcv.Application.Mappings;
using CleanArchMcv.Application.Services;
using CleanArchMcv.Data.Repositories;
using CleanArchMcv.Domain.Interfaces;
using CleanArchMvc.Data.Context;
using CleanArchMvc.Data.Identity.Services;
using CleanArchMvc.Domain.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchMcv.Ioc;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services, IConfiguration configuration)
    {

        //TODO: adicionar a sua string do sql
        services.AddDbContext<ApplicationDbContext>(opitions =>
        opitions.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequiredLength = 7;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredUniqueChars = 1;
        });

        services.AddAuthorization(options =>
        {
            options.AddPolicy("RequiredUserAdminGerenteRoles",
                policy => policy.RequireRole("User", "Admin", "Gerente"));
        });

        services.AddScoped<ICategoryRespository, CategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ICategoryService, CategoryService>();

        services.AddScoped<IAuthenticate, AuthenticateService>();
        services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();

        services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

        var myHandlers = AppDomain.CurrentDomain.Load("CleanArchMcv.Application");
        services.AddMediatR(cfc => cfc.RegisterServicesFromAssemblies(myHandlers));

        return services;
    }
}
