namespace IncomeTaxCalculator.Domain.Exceptions
{
    public class UnsupportedValueException : Exception
    {
        public UnsupportedValueException(decimal value)
            :base($"Can not calculate tax for {value}. Please enter only numeric value.")
        {
        }
    }
}
