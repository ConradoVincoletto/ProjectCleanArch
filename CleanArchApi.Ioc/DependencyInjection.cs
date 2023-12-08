using CleanArch.Application.Interfaces;
using CleanArch.Application.Mappings;
using CleanArch.Application.Services;
using CleanArch.Data.Repositories;
using CleanArch.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) 
        {

            //TODO: adicionar a sua string do sql
            services.AddDbContext<ApplicationDbContext>(opitions =>
            opitions.UseSqlServer(configuration.GetConnectionString("Data Source=LAPTOP-MGPDKJRC\\SQLSERVER2022;Initial Catalog=CLEAN_ARQCH_UDEMY;Integrated Security=True;Encrypt=False;TrustServerCertificate=False"),
            b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<ICategoryRespository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProdutctRepository>();

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            var myHandlers = AppDomain.CurrentDomain.Load("CleanArch.Application");
            services.AddMediatR(myHandlers);

            return services;
        }
    }
}
