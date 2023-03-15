using Klir.TechChallenge.Domain.Interfaces;
using Klir.TechChallenge.Domain.Models;

namespace Klir.TechChallenge.Service.Services.Strategy
{
    public class PromotionStrategyNoPromotion : PromotionStrategy, IPromotionStrategyNoPromotion
    {
        public override ProductPromotion Calculate(Product product, Promotion promotion, int quantityProducts)
        {
            var productPromotion = new ProductPromotion(product, promotion, quantityProducts);
            productPromotion.NoApplyPromotion();

            return productPromotion;
        }
    }
}