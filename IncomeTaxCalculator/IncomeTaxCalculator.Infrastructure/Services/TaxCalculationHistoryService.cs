using IncomeTaxCalculator.Application.Common.Interfaces;
using IncomeTaxCalculator.Domain.Entities;
using IncomeTaxCalculator.Infrastructure.Data;

namespace IncomeTaxCalculator.Infrastructure.Services
{
    public class TaxCalculationHistoryService : ITaxHistoryWriter
    {
        private readonly ApplicationDbContext context;

        public TaxCalculationHistoryService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<int> WriteTaxResultHistory(TaxResult taxResult)
        {
            await context.TaxResults.AddAsync(taxResult);
            return await context.SaveChangesAsync();
        }
    }
}
