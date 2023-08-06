using IncomeTaxCalculator.Domain.Entities;
using IncomeTaxCalculator.Infrastructure.Data;
using IncomeTaxCalculator.Infrastructure.Services;
using FluentAssertions;

namespace Infrastructure.UnitTests.Services
{
    public class TaxCalculationHistoryServiceTests
    {
        [Fact]
        public async Task WriteTaxResultHistory_WriteOneElement_EnsureItCreates()
        {
            // Arrange
            Environment.SetEnvironmentVariable("TaxCalculatorConnectionString", "Server=(localDb)\\MSSQLLocalDB;Database=TaxCalculation;Trusted_Connection=True;");

            TaxCalculationHistoryService taxCalculationService = new TaxCalculationHistoryService(new ApplicationDbContext());

            // Act
            var result = await taxCalculationService.WriteTaxResultHistory(new TaxResult());

            // Assert
            result.Should().Be(1);
        }
    }
}
