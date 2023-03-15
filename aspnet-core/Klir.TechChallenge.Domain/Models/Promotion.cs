using System.Collections.Generic;

namespace Klir.TechChallenge.Domain.Models
{
    public class Promotion
    {
        public int Id { get; set; }
        public int BuyQuantity { get; set; }

        //It can be the cost in the promotion or the quantity of free products, it depends on the promotionType
        public int Result { get; set; }
        public string Currency { get; set; }
        public int PromotionTypeId { get; set; }
        public virtual PromotionType PromotionType { get; set; }
        public virtual IEnumerable<Product> Products { get; set; }

        public string GetPromotionDescription()
        {
            var promotionDescription = PromotionType.Description.Replace("{buy_quantity}", BuyQuantity.ToString());

            if (PromotionTypeId == (int)Enums.PromotionTypes.BuyQuantityAndEarnQuantity)
                promotionDescription = promotionDescription
                .Replace("{free_quantity}", Result.ToString());

            if (PromotionTypeId == (int)Enums.PromotionTypes.BuyQuantityByPrice)
            {
                promotionDescription = promotionDescription
                .Replace("{price}", Result.ToString())
                .Replace("{currency}", Currency).Replace("{currency}", Currency);
            }

            return promotionDescription;
        }
    }
}