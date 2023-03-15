using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Klir.TechChallenge.Domain.Enums;
using Klir.TechChallenge.Domain.Interfaces;
using Klir.TechChallenge.Domain.Models;
using Klir.TechChallenge.Service.Services.Strategy;

namespace Klir.TechChallenge.Service.Services
{
    public class PromotionService : IPromotionService
    {
        private readonly IPromotionRepository _promotionRepository;
        private readonly IPromotionStrategyBuyQuantityEarnQuantity _promotionStrategyBuyQuantityEarnQuantity;
        private readonly IPromotionStrategyQuantityForPrice _promotionStrategyBuyQuantityForPrice;
        private readonly IPromotionStrategyNoPromotion _promotionStrategyNoPromotion;

        public PromotionService(IPromotionRepository promotionRepository,
            IPromotionStrategyBuyQuantityEarnQuantity promotionStrategyBuyQuantityEarnQuantity,
            IPromotionStrategyQuantityForPrice promotionStrategyBuyQuantityForPrice,
            IPromotionStrategyNoPromotion promotionStrategyNoPromotion
        )
        {
            _promotionRepository = promotionRepository;
            _promotionStrategyBuyQuantityEarnQuantity = promotionStrategyBuyQuantityEarnQuantity;
            _promotionStrategyBuyQuantityForPrice = promotionStrategyBuyQuantityForPrice;
            _promotionStrategyNoPromotion = promotionStrategyNoPromotion;
        }
        public int Add(Promotion promotion)
        {
            return _promotionRepository.Add(promotion);
        }

        public ProductPromotion GetProductPromotion(Product product, int quantityProducts)
        {
            if (product.Promotion == null)
            {
                return _promotionStrategyNoPromotion.Calculate(product, product.Promotion, quantityProducts);
            };
            if (product.Promotion.PromotionTypeId == (int)PromotionTypes.BuyQuantityAndEarnQuantity)
            {
                return _promotionStrategyBuyQuantityEarnQuantity.Calculate(product, product.Promotion, quantityProducts);
            }
            else if (product.Promotion.PromotionTypeId == (int)PromotionTypes.BuyQuantityByPrice)
            {
                return _promotionStrategyBuyQuantityForPrice.Calculate(product, product.Promotion, quantityProducts);
            }

            return null;
        }

        public IEnumerable<Promotion> GetAll()
        {
            return _promotionRepository.GetAll();
        }

        public Promotion GetById(int id)
        {
            return _promotionRepository.GetById(id);
        }
    }
}