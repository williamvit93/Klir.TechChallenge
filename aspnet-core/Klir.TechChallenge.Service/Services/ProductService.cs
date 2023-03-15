using System.Collections.Generic;
using Klir.TechChallenge.Domain.Interfaces;
using Klir.TechChallenge.Domain.Models;

namespace Klir.TechChallenge.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public int Add(Product product)
        {
            return _productRepository.Add(product);
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }
    }
}