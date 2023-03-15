using Klir.TechChallenge.Domain.Interfaces;
using Klir.TechChallenge.Repository.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Klir.TechChallenge.Infrastructure.Configurator
{
    public class ServiceConfigurator
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            //Repositories
            services.AddTransient<IProductRepository, ProductRepository>();
        }
    }
}