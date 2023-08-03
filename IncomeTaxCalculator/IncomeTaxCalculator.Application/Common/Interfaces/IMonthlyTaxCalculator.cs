namespace IncomeTaxCalculator.Application.Common.Interfaces
{
    public interface IMonthlyTaxCalculator
    {
        Task<decimal> CalculateGrossMonthlySalary(decimal grossAnnualSalary);
        Task<decimal> CalculateNetMonthlySalary(decimal netAnnualSalary);
        Task<decimal> CalculateMonthlyTaxPaid(decimal annualTaxPaid);
    }
}
