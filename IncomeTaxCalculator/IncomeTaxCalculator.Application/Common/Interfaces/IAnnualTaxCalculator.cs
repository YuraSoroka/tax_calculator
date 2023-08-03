namespace IncomeTaxCalculator.Application.Common.Interfaces
{
    public interface IAnnualTaxCalculator
    {
        Task<decimal> CalculateGrossAnnualSalary(decimal grossAnnualSalary);
        Task<decimal> CalculateNetAnnualSalary(decimal grossAnnualSalary, decimal annualTaxPaid);
        Task<decimal> CalculateAnnualTaxPaid(decimal grossAnnualSalary);
    }
}
