namespace IncomeTaxCalculator.Domain.Entities
{
    public class TaxBand
    {
        public int LowerTaxLimit { get; private init; }
        public int? UpperTaxLimit { get; private init; }
        public decimal TaxRate { get; private init; }
        public TaxBand(
            decimal taxRate,
            int lowerTaxLimit,
            int? upperTaxLimit = default)
        {
            LowerTaxLimit = lowerTaxLimit;
            UpperTaxLimit = upperTaxLimit ?? null;
            TaxRate = taxRate / 100;
        }
    }
}
