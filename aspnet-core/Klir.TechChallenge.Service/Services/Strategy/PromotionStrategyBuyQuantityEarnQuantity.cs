using System;
using Klir.TechChallenge.Domain.Models;

namespace Klir.TechChallenge.Service.Services.Strategy
{
    public class PromotionStrategyBuyQuantityEarnQuantity : PromotionStrategy
    {
        public override ProductPromotion Calculate(Product product, Promotion promotion, int quantityProducts)
        {
            var productPromotion = new ProductPromotion(product, promotion, quantityProducts);
            var quantityToBuyToApplyPromotion = promotion.BuyQuantity == 1 ? promotion.BuyQuantity + 1 : promotion.BuyQuantity;

            var timesPromotionApplied = quantityProducts / quantityToBuyToApplyPromotion;

            var totalPrice = quantityProducts * product.Price;
            var totalDiscount = timesPromotionApplied * product.Price;
            var totalQuantity = quantityProducts + (timesPromotionApplied * promotion.Result);
            var totalQuantityFree = timesPromotionApplied * promotion.Result;
            if (quantityProducts <= 1 || quantityProducts <= quantityToBuyToApplyPromotion)
            {
                productPromotion.NoApplyPromotion();
            }
            else
            {
                productPromotion.ApplyPromotion(totalPrice, totalDiscount, totalQuantity, totalQuantityFree);
            }


            return productPromotion;
        }
    }
}