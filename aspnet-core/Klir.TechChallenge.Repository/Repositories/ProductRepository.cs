using System.Collections.Generic;
using System.Linq;
using Klir.TechChallenge.Domain.Interfaces;
using Klir.TechChallenge.Domain.Models;
using Klir.TechChallenge.Repository.Context;

namespace Klir.TechChallenge.Repository.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }
        public int Add(Product product)
        {
            _context.Add(product);
            return _context.SaveChanges();
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product GetById(int id)
        {
            return _context.Products.FirstOrDefault(product => product.Id == id);
        }
    }
}