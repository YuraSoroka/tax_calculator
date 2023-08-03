using IncomeTaxCalculator.Domain.Common;

namespace IncomeTaxCalculator.Domain.Entities
{
    public class BandBTaxCalculationHandler : TaxCalculationHandler
    {
        public override decimal HandleTax(decimal grossAnnualSalary, TaxBand prevTaxBand)
        {
            if (TaxBandHandler is not null && grossAnnualSalary >= prevTaxBand.UpperTaxLimit)
            {
                TaxBand taxBandC = new TaxBand(
                    40,
                    prevTaxBand.UpperTaxLimit.Value);
                decimal balance = grossAnnualSalary - (prevTaxBand.UpperTaxLimit.Value - prevTaxBand.LowerTaxLimit);
                generalTax += (prevTaxBand.UpperTaxLimit.Value - prevTaxBand.LowerTaxLimit) * prevTaxBand.TaxRate;
                generalTax += TaxBandHandler.HandleTax(balance, taxBandC);
            }
            else
            {
                generalTax += grossAnnualSalary * prevTaxBand.TaxRate;
            }
            return generalTax;
        }
    }
}
