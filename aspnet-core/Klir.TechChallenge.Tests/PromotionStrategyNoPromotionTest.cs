using Klir.TechChallenge.Domain.Models;
using Klir.TechChallenge.Service.Services.Strategy;
using Xunit;

namespace Klir.TechChallenge.Tests
{
    public class PromotionStrategyNoPromotionTest
    {
        [Fact]
        public void ShouldCalculateWithNullablePromotion()
        {
            var expectedPrice = 20;
            var expectedDiscount = 0;
            var expectedPromotionApplied = false;

            var noPromotion = new PromotionStrategyNoPromotion();
            // Arrange
            var quantityProducts = 5;

            Promotion promotion = null;
            var product = new Product
            {
                Id = 1,
                Name = "Product A",
                Price = 4,
                Promotion = promotion,
                PromotionId = null
            };

            // Act
            var productPromotion = noPromotion.Calculate(product, promotion, quantityProducts);

            // Assert
            Assert.Equal(expectedPrice, productPromotion.TotalPrice);
            Assert.Equal(expectedDiscount, productPromotion.TotalDiscount);
            Assert.Equal(expectedPromotionApplied, productPromotion.IsPromotionApplied);
        }
    }
}