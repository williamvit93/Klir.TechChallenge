using System.Collections.Generic;
using AutoMapper;
using Klir.TechChallenge.AppService.Interfaces;
using Klir.TechChallenge.AppService.ViewModels;
using Klir.TechChallenge.Domain.Interfaces;
using Klir.TechChallenge.Domain.Models;

namespace Klir.TechChallenge.AppService.AppServices
{
    public class ProductAppService : IProductAppService
    {
        private IProductService _productService;
        private readonly IMapper _mapper;

        public ProductAppService(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        public int Add(ProductViewModel productViewModel)
        {
            var product = _mapper.Map<Product>(productViewModel);
            return _productService.Add(product);
        }

        public IEnumerable<ProductViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<ProductViewModel>>(_productService.GetAll());
        }

        public ProductViewModel GetById(int id)
        {
            return _mapper.Map<ProductViewModel>(_productService.GetById(id));
        }
    }
}