using IncomeTaxCalculator.Domain.Common;


namespace IncomeTaxCalculator.Domain.Entities
{
    public class BandCTaxCalculationHandler : TaxCalculationHandler
    {
        public override decimal HandleTax(decimal grossAnnualSalary, TaxBand perviousTaxBand)
        {
            if (TaxBandHandler is not null && grossAnnualSalary >= perviousTaxBand.UpperTaxLimit)
            {
                generalTax += perviousTaxBand.UpperTaxLimit.Value * perviousTaxBand.TaxRate;
                generalTax += TaxBandHandler.HandleTax(grossAnnualSalary - perviousTaxBand.UpperTaxLimit.Value, perviousTaxBand);
            }
            else
            {
                generalTax += perviousTaxBand.TaxRate * grossAnnualSalary;
            }
            return generalTax;
        }
    }
}
