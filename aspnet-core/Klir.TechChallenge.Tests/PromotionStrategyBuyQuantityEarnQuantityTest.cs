using System.Collections.Generic;
using Klir.TechChallenge.Domain.Enums;
using Klir.TechChallenge.Domain.Models;
using Klir.TechChallenge.Service.Services.Strategy;
using Xunit;

namespace Klir.TechChallenge.Tests
{
    public class PromotionStrategyBuyQuantityEarnQuantityTest
    {
        [Fact]
        public void ShouldApplyPromotion()
        {
            var expectedPrice = 50;
            var expectedDiscount = 20;
            var expectedQuantityFree = 2;
            var expectedPromotionApplied = true;

            var buyQuantityEarnQuantity = new PromotionStrategyBuyQuantityEarnQuantity();
            // Arrange
            var quantityProducts = 5;
            var promotionType = new PromotionType
            {
                Id = ((int)PromotionTypes.BuyQuantityAndEarnQuantity),
                Description = "Buy 1 Get 1 Free",
                Promotions = new List<Promotion>(),
            };
            var promotion = new Promotion
            {
                Id = 1,
                BuyQuantity = 1,
                Currency = "",
                Result = 1,
                Products = new List<Product>(),
                PromotionType = promotionType,
                PromotionTypeId = promotionType.Id
            };
            var product = new Product
            {
                Id = 1,
                Name = "Product A",
                Price = 10,
                Promotion = promotion,
                PromotionId = null
            };

            // Act
            var productPromotion = buyQuantityEarnQuantity.Calculate(product, promotion, quantityProducts);

            // Assert
            Assert.Equal(expectedPrice, productPromotion.TotalPrice);
            Assert.Equal(expectedDiscount, productPromotion.TotalDiscount);
            Assert.Equal(expectedQuantityFree, productPromotion.TotalQuantityFree);
            Assert.Equal(expectedPromotionApplied, productPromotion.IsPromotionApplied);
        }

        [Fact]
        public void ShouldApplyPromotionWithManyItems()
        {
            var expectedPrice = 90;
            var expectedDiscount = 40;
            var expectedQuantityFree = 4;

            var expectedPromotionApplied = true;

            var buyQuantityEarnQuantity = new PromotionStrategyBuyQuantityEarnQuantity();
            // Arrange
            var quantityProducts = 9;
            var promotionType = new PromotionType
            {
                Id = ((int)PromotionTypes.BuyQuantityAndEarnQuantity),
                Description = "Buy 1 Get 1 Free",
                Promotions = new List<Promotion>(),
            };
            var promotion = new Promotion
            {
                Id = 1,
                BuyQuantity = 1,
                Currency = "",
                Result = 1,
                Products = new List<Product>(),
                PromotionType = promotionType,
                PromotionTypeId = promotionType.Id
            };
            var product = new Product
            {
                Id = 1,
                Name = "Product A",
                Price = 10,
                Promotion = promotion,
                PromotionId = null
            };

            // Act
            var productPromotion = buyQuantityEarnQuantity.Calculate(product, promotion, quantityProducts);

            // Assert
            Assert.Equal(expectedPrice, productPromotion.TotalPrice);
            Assert.Equal(expectedDiscount, productPromotion.TotalDiscount);
            Assert.Equal(expectedQuantityFree, productPromotion.TotalQuantityFree);
            Assert.Equal(expectedPromotionApplied, productPromotion.IsPromotionApplied);
        }

        [Fact]
        public void ShouldNotApplyPromotion()
        {
            var expectedPrice = 10;
            var expectedQuantityFree = 0;
            var expectedDiscount = 0;
            var expectedPromotionApplied = false;

            var buyQuantityEarnQuantity = new PromotionStrategyBuyQuantityEarnQuantity();
            // Arrange
            var quantityProducts = 1;
            var promotionType = new PromotionType
            {
                Id = ((int)PromotionTypes.BuyQuantityAndEarnQuantity),
                Description = "Buy 1 Get 1 Free",
                Promotions = new List<Promotion>(),
            };
            var promotion = new Promotion
            {
                Id = 1,
                BuyQuantity = 1,
                Currency = "",
                Result = 1,
                Products = new List<Product>(),
                PromotionType = promotionType,
                PromotionTypeId = promotionType.Id
            };
            var product = new Product
            {
                Id = 1,
                Name = "Product A",
                Price = 10,
                Promotion = promotion,
                PromotionId = null
            };

            // Act
            var productPromotion = buyQuantityEarnQuantity.Calculate(product, promotion, quantityProducts);

            // Assert
            Assert.Equal(expectedPrice, productPromotion.TotalPrice);
            Assert.Equal(expectedQuantityFree, productPromotion.TotalQuantityFree);
            Assert.Equal(expectedDiscount, productPromotion.TotalDiscount);
            Assert.Equal(expectedPromotionApplied, productPromotion.IsPromotionApplied);
        }

        [Fact]
        public void ShouldNotApplyPromotionWithZeroProducts()
        {
            var expectedPrice = 0;
            var expectedQuantityFree = 0;
            var expectedDiscount = 0;
            var expectedPromotionApplied = false;

            var buyQuantityEarnQuantity = new PromotionStrategyBuyQuantityEarnQuantity();
            // Arrange
            var quantityProducts = 0;
            var promotionType = new PromotionType
            {
                Id = ((int)PromotionTypes.BuyQuantityAndEarnQuantity),
                Description = "Buy 1 Get 1 Free",
                Promotions = new List<Promotion>(),
            };
            var promotion = new Promotion
            {
                Id = 1,
                BuyQuantity = 1,
                Currency = "",
                Result = 1,
                Products = new List<Product>(),
                PromotionType = promotionType,
                PromotionTypeId = promotionType.Id
            };
            var product = new Product
            {
                Id = 1,
                Name = "Product A",
                Price = 10,
                Promotion = promotion,
                PromotionId = null
            };

            // Act
            var productPromotion = buyQuantityEarnQuantity.Calculate(product, promotion, quantityProducts);

            // Assert
            Assert.Equal(expectedPrice, productPromotion.TotalPrice);
            Assert.Equal(expectedQuantityFree, productPromotion.TotalQuantityFree);
            Assert.Equal(expectedDiscount, productPromotion.TotalDiscount);
            Assert.Equal(expectedPromotionApplied, productPromotion.IsPromotionApplied);
        }

        [Fact]
        public void ShouldApplyPromotionBuy3Get1Free()
        {
            var expectedPrice = 60;
            var expectedQuantityFree = 2;
            var expectedDiscount = 20;
            var expectedPromotionApplied = true;

            var buyQuantityEarnQuantity = new PromotionStrategyBuyQuantityEarnQuantity();
            // Arrange
            var quantityProducts = 6;
            var promotionType = new PromotionType
            {
                Id = ((int)PromotionTypes.BuyQuantityAndEarnQuantity),
                Description = "Buy 3 Get 1 Free",
                Promotions = new List<Promotion>(),
            };
            var promotion = new Promotion
            {
                Id = 1,
                BuyQuantity = 3,
                Currency = "",
                Result = 1,
                Products = new List<Product>(),
                PromotionType = promotionType,
                PromotionTypeId = promotionType.Id
            };
            var product = new Product
            {
                Id = 1,
                Name = "Product A",
                Price = 10,
                Promotion = promotion,
                PromotionId = null
            };

            // Act
            var productPromotion = buyQuantityEarnQuantity.Calculate(product, promotion, quantityProducts);

            // Assert
            Assert.Equal(expectedPrice, productPromotion.TotalPrice);
            Assert.Equal(expectedQuantityFree, productPromotion.TotalQuantityFree);
            Assert.Equal(expectedDiscount, productPromotion.TotalDiscount);
            Assert.Equal(expectedPromotionApplied, productPromotion.IsPromotionApplied);
        }
    }
}
