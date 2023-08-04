namespace IncomeTaxCalculator.Application.Common.Interfaces
{
    public interface IAnnualTaxCalculator
    {
        Task<decimal> CalculateNetAnnualSalary(decimal grossAnnualSalary, decimal annualTaxPaid);
        Task<decimal> CalculateAnnualTaxPaid(decimal grossAnnualSalary);
    }
}
