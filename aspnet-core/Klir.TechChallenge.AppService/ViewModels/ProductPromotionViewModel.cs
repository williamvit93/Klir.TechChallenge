namespace Klir.TechChallenge.AppService.ViewModels
{
    public class ProductPromotionViewModel
    {
        public ProductViewModel Product { get; set; }
        public int TotalQuantity { get; set; }
        public int TotalQuantityFree { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TotalDiscount { get; set; }
        public bool IsPromotionApplied { get; set; }
        public PromotionViewModel Promotion { get; set; }
    }
}