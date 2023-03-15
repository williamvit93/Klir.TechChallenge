using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klir.TechChallenge.Domain.Models
{
    public class PromotionType
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public virtual IEnumerable<Promotion> Promotions { get; set; }
    }
}