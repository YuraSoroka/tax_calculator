using IncomeTaxCalculator.Domain.Entities;

namespace IncomeTaxCalculator.Domain.Common
{
    public abstract class TaxCalculationHandler
    {
        public TaxBand TaxBand { get; private init; }
        public decimal generalTax { get; protected set; } = 0;
        public TaxCalculationHandler TaxBandHandler { get; private set; }

        public TaxCalculationHandler(TaxBand taxBand)
        {
            TaxBand = taxBand;
        }

        public abstract decimal HandleTax(decimal grossAnnualSalary);
        public void SetTaxBandHandler(TaxCalculationHandler handler)
        {
            TaxBandHandler = handler;
        }

    }
}
