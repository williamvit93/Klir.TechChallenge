using System.Collections.Generic;
using Klir.TechChallenge.Domain.Models;

namespace Klir.TechChallenge.Domain.Interfaces
{
    public interface IPromotionRepository
    {
        int Add(Promotion promotion);
        Promotion GetById(int id);
        IEnumerable<Promotion> GetAll();
    }
}