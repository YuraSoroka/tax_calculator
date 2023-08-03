using IncomeTaxCalculator.Application.Common.Interfaces;
using IncomeTaxCalculator.Domain.Entities;

namespace IncomeTaxCalculator.Infrastructure.Services
{
    public class TaxCalculatorService : ITaxCalculator
    {
        public Task<TaxResult> CalculateTax(int grossAnnualSalary)
        {
            return Task.FromResult(new TaxResult { Tax = grossAnnualSalary * 2 });
        }
    }
}
