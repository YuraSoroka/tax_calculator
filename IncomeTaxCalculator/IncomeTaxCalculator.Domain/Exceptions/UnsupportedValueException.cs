namespace IncomeTaxCalculator.Domain.Exceptions
{
    public class UnsupportedValueException : Exception
    {
        public UnsupportedValueException(string value)
            :base($"Can not calculate tax for {value}. Please enter only numeric value.")
        {
        }
    }
}
