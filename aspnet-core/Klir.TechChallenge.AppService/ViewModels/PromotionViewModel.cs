namespace Klir.TechChallenge.AppService.ViewModels
{
    public class PromotionViewModel
    {

        public int Id { get; set; }
        public int BuyQuantity { get; set; }

        //It can be the cost in the promotion or the quantity of free products, it depends on the promotionType
        public int Result { get; set; }
        public string Currency { get; set; }
        public int PromotionTypeId { get; set; }
        public string PromotionDescription { get; set; }
        public virtual ProductViewModel Product { get; set; }
    }
}