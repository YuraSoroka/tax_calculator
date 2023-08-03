namespace IncomeTaxCalculator.Domain.Common
{
    public abstract class TaxCalculationHandler
    {
        protected TaxCalculationHandler TaxBandHandler { get; private set; }
        public abstract void HandleTax(int grossAnnualSalary);
        public void SetTaxBandHandler(TaxCalculationHandler handler)
        {
            TaxBandHandler = handler;
        }
    }
}
