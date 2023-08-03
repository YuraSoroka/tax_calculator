namespace IncomeTaxCalculator.Domain.Common
{
    public abstract class TaxBand
    {
        public int LowerTaxLimit { get; private init; }
        public int? UpperTaxLimit { get; private init; }
        public byte TaxRate { get; private init; }
        public DateTime TaxCalculatedAt { get; private init; }
        public TaxBand(
            int lowerTaxLimit, 
            int upperTaxLimit, 
            byte taxRate)
        {
            LowerTaxLimit = lowerTaxLimit;
            UpperTaxLimit = upperTaxLimit;
            TaxRate = taxRate;
            TaxCalculatedAt = DateTime.Now;
        }
    }
}
