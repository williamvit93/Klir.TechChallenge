using Klir.TechChallenge.Domain.Interfaces;
using Klir.TechChallenge.Repository.Repositories;
using Klir.TechChallenge.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Klir.TechChallenge.Infrastructure.Configurator
{
    public class ServiceConfigurator
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            //Services
            services.AddTransient<IProductService, ProductService>();

            //Repositories
            services.AddTransient<IProductRepository, ProductRepository>();
        }
    }
}