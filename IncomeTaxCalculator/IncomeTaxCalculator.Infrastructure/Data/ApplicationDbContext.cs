using IncomeTaxCalculator.Application.Common.Interfaces;
using IncomeTaxCalculator.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IncomeTaxCalculator.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
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
