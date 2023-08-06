using IncomeTaxCalculator.Domain.Common;
using IncomeTaxCalculator.Domain.Entities;

namespace IncomeTaxCalculator.Domain.ValueObjects
{
    public class TaxBandCalculationHandler : TaxCalculationHandler
    {
        public TaxBandCalculationHandler(TaxBand taxband)
            :base(taxband)
        {
        }
    }
}
