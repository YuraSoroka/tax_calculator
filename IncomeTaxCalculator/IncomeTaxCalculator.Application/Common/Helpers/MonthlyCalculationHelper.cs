namespace IncomeTaxCalculator.Application.Common.Helpers
{
    public static class MonthlyCalculationHelper
    {
        private const byte monthCount = 12;
        public static decimal GetMonthlyValue(this decimal annualValue)
        {
            return annualValue / monthCount;
        }
    }
}
