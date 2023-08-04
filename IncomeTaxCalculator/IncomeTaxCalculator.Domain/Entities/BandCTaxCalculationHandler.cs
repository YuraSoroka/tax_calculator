using IncomeTaxCalculator.Domain.Common;


namespace IncomeTaxCalculator.Domain.Entities
{
    public class BandCTaxCalculationHandler : TaxCalculationHandler
    {
        public BandCTaxCalculationHandler(TaxBand taxband)
            : base(taxband)
        {
        }
        public override decimal HandleTax(decimal grossAnnualSalary)
        {
            if (TaxBandHandler is not null && grossAnnualSalary >= TaxBand.UpperTaxLimit)
            {
                generalTax += TaxBand.UpperTaxLimit.Value * TaxBand.TaxRate;
                generalTax += TaxBandHandler.HandleTax(grossAnnualSalary - TaxBand.UpperTaxLimit.Value);
            }
            else
            {
                generalTax += TaxBand.TaxRate * grossAnnualSalary;
            }
            return generalTax;
        }
    }
}
