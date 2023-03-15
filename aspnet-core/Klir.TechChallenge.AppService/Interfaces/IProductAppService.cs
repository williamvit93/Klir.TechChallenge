using System.Collections.Generic;
using Klir.TechChallenge.AppService.ViewModels;

namespace Klir.TechChallenge.AppService.Interfaces
{
    public interface IProductAppService
    {
        int Add(ProductViewModel productViewModel);
        ProductViewModel GetById(int id);
        IEnumerable<ProductViewModel> GetAll();
    }
}