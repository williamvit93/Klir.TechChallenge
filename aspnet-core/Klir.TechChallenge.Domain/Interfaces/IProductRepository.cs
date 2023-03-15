using System.Collections.Generic;
using Klir.TechChallenge.Domain.Models;

namespace Klir.TechChallenge.Domain.Interfaces
{
    public interface IProductRepository
    {
        int Add(Product product);
        Product GetById(int id);
        IEnumerable<Product> GetAll();
    }
}