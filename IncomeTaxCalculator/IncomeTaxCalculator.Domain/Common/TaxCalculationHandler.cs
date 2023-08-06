using IncomeTaxCalculator.Domain.Entities;
using IncomeTaxCalculator.Domain.Exceptions;

namespace IncomeTaxCalculator.Domain.Common
{
    public abstract class TaxCalculationHandler
    {
        public TaxBand TaxBand { get; private init; }
        public decimal GeneralTax { get; protected set; } = 0;
        public TaxCalculationHandler TaxBandHandler { get; private set; }

        public TaxCalculationHandler(TaxBand taxBand)
        {
            TaxBand = taxBand;
        }

        public virtual decimal HandleTax(decimal grossAnnualSalary)
        {
            if (grossAnnualSalary < 0)
            {
                throw new UnsupportedValueException(grossAnnualSalary);
            }
            if (TaxBandHandler is not null && grossAnnualSalary >= TaxBand.UpperTaxLimit)
            {
                decimal balance = grossAnnualSalary - (TaxBand.UpperTaxLimit.Value - TaxBand.LowerTaxLimit);
                GeneralTax += (TaxBand.UpperTaxLimit.Value - TaxBand.LowerTaxLimit) * TaxBand.TaxRate;
                GeneralTax += TaxBandHandler.HandleTax(balance);
            }
            else
            {
                GeneralTax += grossAnnualSalary * TaxBand.TaxRate;
            }
            return GeneralTax;
        }
        public void SetTaxBandHandler(TaxCalculationHandler handler)
        {
            TaxBandHandler = handler;
        }

    }
}
