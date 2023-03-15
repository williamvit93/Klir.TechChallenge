using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Klir.TechChallenge.AppService.Interfaces;
using Klir.TechChallenge.AppService.ViewModels;
using Klir.TechChallenge.Domain.Interfaces;

namespace Klir.TechChallenge.AppService.AppServices
{
    public class CheckoutAppService : ICheckoutAppService
    {

        private readonly IProductService _productService;
        private readonly IPromotionService _promotionService;
        private readonly IMapper _mapper;
        public CheckoutAppService(IProductService productService, IPromotionService promotionService, IMapper mapper)
        {
            _productService = productService;
            _promotionService = promotionService;
            _mapper = mapper;
        }
        public IEnumerable<ProductPromotionViewModel> CalculateProductPromotions(IEnumerable<ProductViewModel> productsViewModel)
        {
            var productPromotions = new List<ProductPromotionViewModel>();
            var addedProducts =
                                 productsViewModel.GroupBy(p => p.Id).Select(g
                                    => new
                                    {
                                        ProductId = g.Key,
                                        Quantity = g.Count()
                                    })
                                 .ToList();

            foreach (var addedProduct in addedProducts)
            {
                var product = _productService.GetById(addedProduct.ProductId);
                var productPromotion = _promotionService.GetProductPromotion(product, addedProduct.Quantity);
                productPromotions.Add(_mapper.Map<ProductPromotionViewModel>(productPromotion));
            }

            return productPromotions;
        }
    }
}