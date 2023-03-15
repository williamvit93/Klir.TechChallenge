using System.Collections.Generic;

namespace Klir.TechChallenge.Domain.Models
{
    public class PromotionType
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public virtual IEnumerable<Promotion> Promotions { get; set; }
    }
}