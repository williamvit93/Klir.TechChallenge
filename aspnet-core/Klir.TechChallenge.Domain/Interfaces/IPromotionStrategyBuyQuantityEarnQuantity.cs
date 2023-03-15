using Klir.TechChallenge.Domain.Models;

namespace Klir.TechChallenge.Domain.Interfaces
{
    public interface IPromotionStrategyBuyQuantityEarnQuantity
    {
        ProductPromotion Calculate(Product product, Promotion promotion, int quantityProducts);
    }
}