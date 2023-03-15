using Klir.TechChallenge.Domain.Models;

namespace Klir.TechChallenge.Service.Services.Strategy
{
    public class PromotionStrategyQuantityForPrice : PromotionStrategy
    {
        public override ProductPromotion Calculate(Product product, Promotion promotion, int quantityProducts)
        {
            var productPromotion = new ProductPromotion(product, promotion, quantityProducts);
            var timesPromotionApplied = quantityProducts / promotion.BuyQuantity;
            if (timesPromotionApplied >= 1)
            {
                var quantityProductsInPromotion = timesPromotionApplied * promotion.BuyQuantity;
                var totalPrice = (timesPromotionApplied * promotion.Result) + ((quantityProducts - quantityProductsInPromotion) * product.Price);
                var totalDiscount = (quantityProducts * product.Price) - totalPrice;

                productPromotion.ApplyPromotion(totalPrice, totalDiscount);
            }
            else
            {
                productPromotion.NoApplyPromotion();
            }

            return productPromotion;
        }
    }
}