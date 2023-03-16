using System.Collections.Generic;
using System.Linq;
using Klir.TechChallenge.Domain.Interfaces;
using Klir.TechChallenge.Domain.Models;
using Klir.TechChallenge.Repository.Context;

namespace Klir.TechChallenge.Repository.Repositories
{
    public class PromotionRepository : IPromotionRepository
    {

        private readonly DataContext _context;

        public PromotionRepository(DataContext context)
        {
            _context = context;
        }
        public int Add(Promotion promotion)
        {
            _context.Add(promotion);
            return _context.SaveChanges();
        }

        public IEnumerable<Promotion> GetAll()
        {
            return _context.Promotions.ToList();
        }

        public Promotion GetById(int id)
        {
            return _context.Promotions.FirstOrDefault(promotion => promotion.Id == id);
        }

    }
}