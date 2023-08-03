using IncomeTaxCalculator.Domain.Common;

namespace IncomeTaxCalculator.Domain.Entities
{
    public class TaxBandC : TaxBand
    {
        public TaxBandC(int lowerTaxLimit, int upperTaxLimit, byte taxRate)
            :base(lowerTaxLimit, upperTaxLimit, taxRate)
        {

        }
    }
}
