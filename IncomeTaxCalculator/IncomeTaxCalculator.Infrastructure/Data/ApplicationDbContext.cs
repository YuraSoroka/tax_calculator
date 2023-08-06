using IncomeTaxCalculator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace IncomeTaxCalculator.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        private IConfiguration configuration;
        public ApplicationDbContext(IConfiguration config)
        {
            configuration = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("TaxCalculatorConnectionString"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaxResult>()
                .HasKey(tr => tr.Id);
        }
        public DbSet<TaxResult> TaxResults { get; set; }
    }
}
