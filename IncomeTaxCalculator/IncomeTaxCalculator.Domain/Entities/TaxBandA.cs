using IncomeTaxCalculator.Domain.Common;

namespace IncomeTaxCalculator.Domain.Entities
{
    public class TaxBandA : TaxBand
    {
        public TaxBandA(int lowerTaxLimit, int upperTaxLimit, byte taxRate)
            : base(lowerTaxLimit, upperTaxLimit, taxRate)
        {

        }
    }
}
