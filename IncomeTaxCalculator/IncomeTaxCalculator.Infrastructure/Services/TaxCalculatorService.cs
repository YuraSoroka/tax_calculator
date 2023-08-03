using IncomeTaxCalculator.Application.Common.Interfaces;
using IncomeTaxCalculator.Domain.Common;
using IncomeTaxCalculator.Domain.Entities;

namespace IncomeTaxCalculator.Infrastructure.Services
{
    public class TaxCalculatorService : IAnnualTaxCalculator, IMonthlyTaxCalculator
    {
        private readonly byte monthCount = 12;
        public Task<decimal> CalculateAnnualTaxPaid(decimal grossAnnualSalary)
        {
            TaxCalculationHandler taxBandACalculationHandler = new BandATaxCalculationHandler();
            TaxCalculationHandler taxBandBCalculationHandler = new BandBTaxCalculationHandler();
            TaxCalculationHandler taxBandCCalculationHandler = new BandCTaxCalculationHandler();

            taxBandACalculationHandler.SetTaxBandHandler(taxBandBCalculationHandler);
            taxBandBCalculationHandler.SetTaxBandHandler(taxBandCCalculationHandler);
            TaxBand taxBandA = new TaxBand(0, 0, 5000);

            return Task.FromResult(taxBandACalculationHandler.HandleTax(grossAnnualSalary, taxBandA));
        }

        public Task<decimal> CalculateGrossAnnualSalary(decimal grossAnnualSalary)
        {
            return Task.FromResult(grossAnnualSalary);
        }
        public Task<decimal> CalculateNetAnnualSalary(decimal grossAnnualSalary, decimal annualTaxPaid)
        {
            return Task.FromResult(grossAnnualSalary - annualTaxPaid);
        }

        public Task<decimal> CalculateGrossMonthlySalary(decimal grossAnnualSalary)
        {
            return Task.FromResult(grossAnnualSalary / monthCount);
        }

        public Task<decimal> CalculateMonthlyTaxPaid(decimal annualTaxPaid)
        {
            return Task.FromResult(annualTaxPaid / monthCount);
        }


        public Task<decimal> CalculateNetMonthlySalary(decimal netAnnualSalary)
        {
            return Task.FromResult(netAnnualSalary / monthCount);
        }
    }
}
