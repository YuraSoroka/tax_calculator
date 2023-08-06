using IncomeTaxCalculator.Infrastructure.Services;
using FluentAssertions;

namespace Infrastructure.UnitTests.Services
{
    public class TaxCalculationServiceTests
    {
        [Theory]
        [InlineData(40000, 11000)]
        [InlineData(10000, 1000)]
        public async Task CalculateAnnualTaxPaid_EnterExampleSalary_Returns11000(decimal grossAnnualSalary, decimal expected)
        {
            // Arrange
            TaxCalculatorService taxCalculationService = new TaxCalculatorService();

            // Act
            var result = await taxCalculationService.CalculateAnnualTaxPaid(grossAnnualSalary);

            // Assert
            result.Should().Be(expected);
        }
    }
}
