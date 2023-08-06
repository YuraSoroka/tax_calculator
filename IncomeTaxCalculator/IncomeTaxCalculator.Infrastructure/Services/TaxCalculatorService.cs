using IncomeTaxCalculator.Application.Common.Interfaces;
using IncomeTaxCalculator.Domain.Common;
using IncomeTaxCalculator.Domain.Entities;

namespace IncomeTaxCalculator.Infrastructure.Services
{
    public class TaxCalculatorService : IAnnualTaxCalculator
    {
        public Task<decimal> CalculateAnnualTaxPaid(decimal grossAnnualSalary)
        {
            TaxBand taxBandA = new TaxBand(0, 0, 5000);
            TaxBand taxBandB = new TaxBand(20, taxBandA.UpperTaxLimit.Value, 20000);
            TaxBand taxBandC = new TaxBand(40, taxBandB.UpperTaxLimit.Value);

            TaxCalculationHandler taxBandACalculationHandler = new BandATaxCalculationHandler(taxBandA);
            TaxCalculationHandler taxBandBCalculationHandler = new BandBTaxCalculationHandler(taxBandB);
            TaxCalculationHandler taxBandCCalculationHandler = new BandCTaxCalculationHandler(taxBandC);

            taxBandACalculationHandler.SetTaxBandHandler(taxBandBCalculationHandler);
            taxBandBCalculationHandler.SetTaxBandHandler(taxBandCCalculationHandler);
             
            return Task.Run(() => taxBandACalculationHandler.HandleTax(grossAnnualSalary));
        }

        public Task<decimal> CalculateNetAnnualSalary(decimal grossAnnualSalary, decimal annualTaxPaid)
        {
            return Task.FromResult(grossAnnualSalary - annualTaxPaid);
        }

    }
}
