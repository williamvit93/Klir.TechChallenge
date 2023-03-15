using System.Collections.Generic;
using Klir.TechChallenge.Domain.Enums;
using Klir.TechChallenge.Domain.Models;
using Klir.TechChallenge.Service.Services.Strategy;
using Xunit;

namespace Klir.TechChallenge.Tests
{
    public class PromotionStrategyQuantityForPriceTest
    {
        [Fact]
        public void ShouldApplyPromotion()
        {
            var expectedPrice = 18;
            var expectedDiscount = 2;
            var expectedPromotionApplied = true;

            var quantityForPrice = new PromotionStrategyQuantityForPrice();
            // Arrange
            var quantityProducts = 5;
            var promotionType = new PromotionType
            {
                Id = ((int)PromotionTypes.BuyQuantityByPrice),
                Description = "3 For 10 Euro",
                Promotions = new List<Promotion>(),
            };
            var promotion = new Promotion
            {
                Id = 1,
                BuyQuantity = 3,
                Currency = "Euro",
                Result = 10,
                Products = new List<Product>(),
                PromotionType = promotionType,
                PromotionTypeId = promotionType.Id
            };
            var product = new Product
            {
                Id = 1,
                Name = "Product A",
                Price = 4,
                Promotion = promotion,
                PromotionId = null
            };

            // Act
            var productPromotion = quantityForPrice.Calculate(product, promotion, quantityProducts);

            // Assert
            Assert.Equal(expectedPrice, productPromotion.TotalPrice);
            Assert.Equal(expectedDiscount, productPromotion.TotalDiscount);
            Assert.Equal(expectedPromotionApplied, productPromotion.IsPromotionApplied);
        }

        [Fact]
        public void ShouldApplyPromotionWithManyItems()
        {
            var expectedPrice = 30;
            var expectedDiscount = 6;
            var expectedPromotionApplied = true;

            var quantityForPrice = new PromotionStrategyQuantityForPrice();
            // Arrange
            var quantityProducts = 9;
            var promotionType = new PromotionType
            {
                Id = 1,
                Description = "3 For 10 Euro",
                Promotions = new List<Promotion>(),
            };
            var promotion = new Promotion
            {
                Id = 1,
                BuyQuantity = 3,
                Currency = "Euro",
                Result = 10,
                Products = new List<Product>(),
                PromotionType = promotionType,
                PromotionTypeId = promotionType.Id
            };
            var product = new Product
            {
                Id = 1,
                Name = "Product A",
                Price = 4,
                Promotion = promotion,
                PromotionId = null
            };

            // Act
            var productPromotion = quantityForPrice.Calculate(product, promotion, quantityProducts);

            // Assert
            Assert.Equal(expectedPrice, productPromotion.TotalPrice);
            Assert.Equal(expectedDiscount, productPromotion.TotalDiscount);
            Assert.Equal(expectedPromotionApplied, productPromotion.IsPromotionApplied);
        }

        [Fact]
        public void ShouldNotApplyPromotion()
        {
            var expectedPrice = 8;
            var expectedDiscount = 0;
            var expectedPromotionApplied = false;

            var quantityForPrice = new PromotionStrategyQuantityForPrice();
            // Arrange
            var quantityProducts = 2;
            var promotionType = new PromotionType
            {
                Id = 1,
                Description = "3 For 10 Euro",
                Promotions = new List<Promotion>(),
            };
            var promotion = new Promotion
            {
                Id = 1,
                BuyQuantity = 3,
                Currency = "Euro",
                Result = 10,
                Products = new List<Product>(),
                PromotionType = promotionType,
                PromotionTypeId = promotionType.Id
            };
            var product = new Product
            {
                Id = 1,
                Name = "Product A",
                Price = 4,
                Promotion = promotion,
                PromotionId = null
            };

            // Act
            var productPromotion = quantityForPrice.Calculate(product, promotion, quantityProducts);

            // Assert
            Assert.Equal(expectedPrice, productPromotion.TotalPrice);
            Assert.Equal(expectedDiscount, productPromotion.TotalDiscount);
            Assert.Equal(expectedPromotionApplied, productPromotion.IsPromotionApplied);
        }

        [Fact]
        public void ShouldNotApplyPromotionWithZeroProducts()
        {
            var expectedPrice = 0;
            var expectedDiscount = 0;
            var expectedPromotionApplied = false;

            var quantityForPrice = new PromotionStrategyQuantityForPrice();
            // Arrange
            var quantityProducts = 0;
            var promotionType = new PromotionType
            {
                Id = 1,
                Description = "3 For 10 Euro",
                Promotions = new List<Promotion>(),
            };
            var promotion = new Promotion
            {
                Id = 1,
                BuyQuantity = 3,
                Currency = "Euro",
                Result = 10,
                Products = new List<Product>(),
                PromotionType = promotionType,
                PromotionTypeId = promotionType.Id
            };
            var product = new Product
            {
                Id = 1,
                Name = "Product A",
                Price = 4,
                Promotion = promotion,
                PromotionId = null
            };

            // Act
            var productPromotion = quantityForPrice.Calculate(product, promotion, quantityProducts);

            // Assert
            Assert.Equal(expectedPrice, productPromotion.TotalPrice);
            Assert.Equal(expectedDiscount, productPromotion.TotalDiscount);
            Assert.Equal(expectedPromotionApplied, productPromotion.IsPromotionApplied);
        }

        [Fact]
        public void ShouldApplyPromotion4For20Euro()
        {
            var expectedPrice = 26;
            var expectedDiscount = 4;
            var expectedPromotionApplied = true;

            var quantityForPrice = new PromotionStrategyQuantityForPrice();
            // Arrange
            var quantityProducts = 5;
            var promotionType = new PromotionType
            {
                Id = ((int)PromotionTypes.BuyQuantityByPrice),
                Description = "4 For 20 Euro",
                Promotions = new List<Promotion>(),
            };
            var promotion = new Promotion
            {
                Id = 1,
                BuyQuantity = 4,
                Currency = "Euro",
                Result = 20,
                Products = new List<Product>(),
                PromotionType = promotionType,
                PromotionTypeId = promotionType.Id
            };
            var product = new Product
            {
                Id = 1,
                Name = "Product A",
                Price = 6,
                Promotion = promotion,
                PromotionId = null
            };

            // Act
            var productPromotion = quantityForPrice.Calculate(product, promotion, quantityProducts);

            // Assert
            Assert.Equal(expectedPrice, productPromotion.TotalPrice);
            Assert.Equal(expectedDiscount, productPromotion.TotalDiscount);
            Assert.Equal(expectedPromotionApplied, productPromotion.IsPromotionApplied);
        }
    }
}