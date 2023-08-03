using IncomeTaxCalculator.Domain.Common;

namespace IncomeTaxCalculator.Domain.Entities
{
    public class BandATaxCalculationHandler : TaxCalculationHandler
    {
        public override decimal HandleTax(decimal grossAnnualSalary, TaxBand prevTaxBand)
        {
            if (TaxBandHandler is not null && grossAnnualSalary >= prevTaxBand.UpperTaxLimit)
            {
                TaxBand taxBandB = new TaxBand(
                    20,
                    prevTaxBand.UpperTaxLimit.Value, 
                    20000);
                decimal balance = grossAnnualSalary - prevTaxBand.UpperTaxLimit.Value;
                generalTax += prevTaxBand.UpperTaxLimit.Value * prevTaxBand.TaxRate;
                generalTax += TaxBandHandler.HandleTax(balance, taxBandB);
            }
            else
            {
                generalTax += grossAnnualSalary * prevTaxBand.TaxRate;
            }
            return generalTax;
        }
    }
}
