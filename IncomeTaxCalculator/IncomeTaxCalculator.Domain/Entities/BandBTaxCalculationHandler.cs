using IncomeTaxCalculator.Domain.Common;

namespace IncomeTaxCalculator.Domain.Entities
{
    public class BandBTaxCalculationHandler : TaxCalculationHandler
    {
        public BandBTaxCalculationHandler(TaxBand taxband)
            : base(taxband)
        {
        }
        public override decimal HandleTax(decimal grossAnnualSalary)
        {
            if (TaxBandHandler is not null && grossAnnualSalary >= TaxBand.UpperTaxLimit)
            {
                decimal balance = grossAnnualSalary - (TaxBand.UpperTaxLimit.Value - TaxBand.LowerTaxLimit);
                generalTax += (TaxBand.UpperTaxLimit.Value - TaxBand.LowerTaxLimit) * TaxBand.TaxRate;
                generalTax += TaxBandHandler.HandleTax(balance);
            }
            else
            {
                generalTax += grossAnnualSalary * TaxBand.TaxRate;
            }
            return generalTax;
        }
    }
}
