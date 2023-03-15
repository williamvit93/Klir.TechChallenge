using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klir.TechChallenge.Domain.Interfaces
{
    public interface IPromotionService
    {
        int Add(Promotion promotion);
        Promotion GetById(int id);
        IEnumerable<Promotion> GetAll();
    }
}