using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Klir.TechChallenge.Repository.Context
{
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        DataContext IDesignTimeDbContextFactory<DataContext>.CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            DbContextOptionsBuilder<DataContext> builder = new DbContextOptionsBuilder<DataContext>();
            string connectionString = configuration.GetConnectionString("Default");
            builder.UseSqlite(connectionString);

            return new DataContext(builder.Options);
        }
    }
}