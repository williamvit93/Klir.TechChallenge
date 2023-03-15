using Klir.TechChallenge.Domain.Models;

namespace Klir.TechChallenge.Domain.Interfaces
{
    public interface IPromotionStrategyNoPromotion
    {
        ProductPromotion Calculate(Product product, Promotion promotion, int quantityProducts);
    }
}