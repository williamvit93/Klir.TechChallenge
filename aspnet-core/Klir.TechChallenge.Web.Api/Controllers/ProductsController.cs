using System.Collections.Generic;
using Klir.TechChallenge.AppService.Interfaces;
using Klir.TechChallenge.AppService.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Klir.TechChallenge.Web.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductAppService _productAppService;
        public ProductsController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        [HttpGet]
        public IEnumerable<ProductViewModel> Get()
        {
            return _productAppService.GetAll();
        }
    }
}