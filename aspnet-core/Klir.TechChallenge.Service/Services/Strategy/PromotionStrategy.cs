using Klir.TechChallenge.Domain.Models;

namespace Klir.TechChallenge.Service.Services.Strategy
{
    public abstract class PromotionStrategy
    {
        public abstract ProductPromotion Calculate(Product product, Promotion promotion, int quantityProducts);
    }
}