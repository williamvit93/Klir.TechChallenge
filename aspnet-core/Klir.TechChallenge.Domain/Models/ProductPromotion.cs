namespace Klir.TechChallenge.Domain.Models
{
    public class ProductPromotion
    {
        public ProductPromotion(Product product, Promotion promotion, int totalQuantity)
        {
            this.Product = product;
            this.Promotion = promotion;
            this.TotalQuantity = totalQuantity;
        }

        public Product Product { get; }
        private int _totalQuantity;
        public int TotalQuantity
        {
            get { return _totalQuantity; }
            protected set { _totalQuantity = value; }
        }
        private int _totalQuantityFree;
        public int TotalQuantityFree
        {
            get { return _totalQuantityFree; }
            protected set { _totalQuantityFree = value; }
        }
        private decimal _totalPrice;
        public decimal TotalPrice
        {
            get { return _totalPrice; }
            protected set { _totalPrice = value; }
        }
        private decimal _totalDiscount;
        public decimal TotalDiscount
        {
            get { return _totalDiscount; }
            protected set { _totalDiscount = value; }
        }
        private bool _isPromotionApplied;
        public bool IsPromotionApplied
        {
            get { return _isPromotionApplied; }
            protected set { _isPromotionApplied = value; }
        }
        public Promotion Promotion { get; set; }

        public void ApplyPromotion(decimal totalPrice, decimal totalDiscount, int? totalQuantity = null, int? totalQuantityFree = null)
        {
            IsPromotionApplied = true;
            TotalPrice = totalPrice;
            TotalDiscount = totalDiscount;
            TotalQuantity = totalQuantity.HasValue ? totalQuantity.Value : TotalQuantity;
            TotalQuantityFree = totalQuantityFree.HasValue ? totalQuantityFree.Value : 0;
        }

        public void NoApplyPromotion()
        {
            IsPromotionApplied = false;
            TotalPrice = TotalQuantity * Product.Price;
            TotalDiscount = 0;
            TotalQuantityFree = 0;
        }
    }
}