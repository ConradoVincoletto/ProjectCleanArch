﻿using CleanArch.Application.Interfaces;
using CleanArch.Application.Mappings;
using CleanArch.Application.Services;
using CleanArch.Data.Repositories;
using CleanArch.Domain.Interfaces;
using CleanArchMvc.Data.Identity.Services;
using CleanArchMvc.Domain.Account;
using CleanArchMvc.Infra.Data.Context;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApiIdentity.Services;

namespace CleanArch.Ioc;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services, IConfiguration configuration)
    {

        //TODO: adicionar a sua string do sql
        services.AddDbContext<ApplicationDbContext>(opitions =>
        opitions.UseSqlServer(configuration.GetConnectionString("Data Source=LAPTOP-MGPDKJRC\\SQLSERVER2022;Initial Catalog=CLEAN_ARQCH_UDEMY;Integrated Security=True;Encrypt=False;TrustServerCertificate=False"),
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

        var myHandlers = AppDomain.CurrentDomain.Load("CleanArch.Application");
        services.AddMediatR(cfc => cfc.RegisterServicesFromAssemblies(myHandlers));

        return services;
    }
}
