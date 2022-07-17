using Commify.TaxCalculator.Core.DataAccess.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Commify.TaxCalculator.Infrastructure.Contexts
{
    public class TaxCalculatorContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //TODO: read connectionstring from configuration
            var connectionString = "DataSource=TaxCalculatorDb;mode=memory;cache=shared";
            var keepAliveConnection = new SqliteConnection(connectionString);
            keepAliveConnection.Open();

            optionsBuilder.UseSqlite(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaxBand>().HasData(
                new TaxBand
                {
                    Id = Guid.NewGuid(),
                    Name = "TaxBandA",
                    SalaryLowerLimit = 0,
                    SalaryUpperLimit = 5000,
                    TaxRate = 0
                },
                new TaxBand
                {
                    Id = Guid.NewGuid(),
                    Name = "TaxBandB",
                    SalaryLowerLimit = 5000,
                    SalaryUpperLimit = 20000,
                    TaxRate = 20
                },
                new TaxBand
                {
                    Id = Guid.NewGuid(),
                    Name = "TaxBandC",
                    SalaryLowerLimit = 20000,
                    SalaryUpperLimit = null,
                    TaxRate = 40
                }
            );
        }

        public DbSet<TaxBand> TaxBands { get; set; }
    }
}
