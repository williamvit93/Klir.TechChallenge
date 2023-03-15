using Klir.TechChallenge.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Klir.TechChallenge.Repository.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<PromotionType> PromotionTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Promotion>().HasOne(p => p.PromotionType).WithMany(p => p.Promotions).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<PromotionType>().HasMany(p => p.Promotions).WithOne(p => p.PromotionType).OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}