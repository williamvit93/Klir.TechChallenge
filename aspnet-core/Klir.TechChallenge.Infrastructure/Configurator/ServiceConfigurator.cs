using Klir.TechChallenge.AppService.AppServices;
using Klir.TechChallenge.AppService.Interfaces;
using Klir.TechChallenge.Domain.Interfaces;
using Klir.TechChallenge.Repository.Repositories;
using Klir.TechChallenge.Service.Services;
using Klir.TechChallenge.Service.Services.Strategy;
using Microsoft.Extensions.DependencyInjection;

namespace Klir.TechChallenge.Infrastructure.Configurator
{
    public class ServiceConfigurator
    {
        public static void ConfigureServices(IServiceCollection services)
        {

            //AppServices
            services.AddTransient<IProductAppService, ProductAppService>();
            services.AddTransient<IPromotionStrategyBuyQuantityEarnQuantity, PromotionStrategyBuyQuantityEarnQuantity>();
            services.AddTransient<IPromotionStrategyQuantityForPrice, PromotionStrategyQuantityForPrice>();
            services.AddTransient<IPromotionStrategyNoPromotion, PromotionStrategyNoPromotion>();

            //Services
            services.AddTransient<IProductService, ProductService>();

            //Repositories
            services.AddTransient<IProductRepository, ProductRepository>();
        }
    }
}