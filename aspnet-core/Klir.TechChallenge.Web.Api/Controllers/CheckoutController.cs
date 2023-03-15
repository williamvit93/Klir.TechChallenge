using System.Collections.Generic;
using Klir.TechChallenge.AppService.Interfaces;
using Klir.TechChallenge.AppService.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Klir.TechChallenge.Web.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CheckoutController : ControllerBase
    {
        private readonly ICheckoutAppService _checkoutAppService;
        public CheckoutController(ICheckoutAppService checkoutAppService)
        {
            _checkoutAppService = checkoutAppService;
        }

        [HttpPost]
        public IEnumerable<ProductPromotionViewModel> Post(IList<ProductViewModel> products)
        {
            return _checkoutAppService.CalculateProductPromotions(products);
        }
    }
}