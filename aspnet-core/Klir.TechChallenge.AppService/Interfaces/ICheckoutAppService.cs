using System.Collections.Generic;
using Klir.TechChallenge.AppService.ViewModels;

namespace Klir.TechChallenge.AppService.Interfaces
{
    public interface ICheckoutAppService
    {
        IEnumerable<ProductPromotionViewModel> CalculateProductPromotions(IEnumerable<ProductViewModel> productsViewModel);
    }
}