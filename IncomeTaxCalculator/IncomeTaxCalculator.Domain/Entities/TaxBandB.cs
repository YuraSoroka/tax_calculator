using IncomeTaxCalculator.Domain.Common;

namespace IncomeTaxCalculator.Domain.Entities
{
    public class TaxBandB : TaxBand
    {
        public TaxBandB(int lowerTaxLimit, int upperTaxLimit, byte taxRate)
            : base(lowerTaxLimit, upperTaxLimit, taxRate)
        {

        }
    }
}
