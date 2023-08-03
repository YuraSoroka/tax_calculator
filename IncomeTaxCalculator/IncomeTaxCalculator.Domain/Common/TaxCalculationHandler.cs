using IncomeTaxCalculator.Domain.Entities;

namespace IncomeTaxCalculator.Domain.Common
{
    public abstract class TaxCalculationHandler
    {
        public decimal generalTax { get; protected set; } = 0;
        protected TaxCalculationHandler TaxBandHandler { get; private set; }
        public abstract decimal HandleTax(decimal grossAnnualSalary, TaxBand perviousTaxBand);
        public void SetTaxBandHandler(TaxCalculationHandler handler)
        {
            TaxBandHandler = handler;
        }

    }
}
