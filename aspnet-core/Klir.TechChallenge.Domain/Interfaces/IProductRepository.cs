using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klir.TechChallenge.Domain.Interfaces
{
    public interface IProductRepository
    {
        int Add(Product product);
        Product GetById(int id);
        IEnumerable<Product> GetAll();
    }
}