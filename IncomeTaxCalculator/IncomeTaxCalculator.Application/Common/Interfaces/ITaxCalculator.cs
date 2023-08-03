using IncomeTaxCalculator.Domain.Entities;

namespace IncomeTaxCalculator.Application.Common.Interfaces
{
    public interface ITaxCalculator
    {
        Task<TaxResult> CalculateTax(int grossAnnualSalary);
    }
}
