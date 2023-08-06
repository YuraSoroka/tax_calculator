using IncomeTaxCalculator.Domain.Entities;
using IncomeTaxCalculator.Domain.ValueObjects;
using FluentAssertions;
using IncomeTaxCalculator.Domain.Exceptions;

namespace Domain.UnitTests.ValueObjects
{
    public class TaxBandCalculationHandlerTests
    {
        [Theory]
        [InlineData(2500)]
        [InlineData(1000)]
        [InlineData(1)]
        public void HandleTax_PassLessSalaryValueThanBandLimitAndZoroTaxRate_ReturnsZeroTax(decimal grossAnnualSalary)
        {
            // Arrange
            decimal taxRate = 0;
            int upperBandLimit = (int)grossAnnualSalary * 2;
            TaxBandCalculationHandler bandATaxCalculationHandler = new TaxBandCalculationHandler(new TaxBand(taxRate, 0, upperBandLimit));
            
            // Act
            var result = bandATaxCalculationHandler.HandleTax(grossAnnualSalary);

            // Assert
            result.Should().Be(0);
        }

        [Fact]
        public void GeneralTax_CheckStartGeneralTax_ReturnsZero()
        {
            // Arrange

            TaxBandCalculationHandler bandATaxCalculationHandler = new TaxBandCalculationHandler(new TaxBand(0, 0, 0));

            // Act
            var result = bandATaxCalculationHandler.GeneralTax;

            // Assert
            result.Should().Be(0);
        }

        [Theory]
        [InlineData(500)]
        [InlineData(750)]
        [InlineData(1000)]
        public void HandleTax_PassTaxRateAndSalaryValueLessThatUpperLimit_ReturnsCorrectTaxValue(decimal grossAnnualSalary)
        {
            // Arrange
            decimal taxRate = 10;
            int upperBandLimit = (int)grossAnnualSalary * 2;
            TaxBandCalculationHandler bandATaxCalculationHandler = new TaxBandCalculationHandler(new TaxBand(taxRate, 0, upperBandLimit));

            // Act
            var result = bandATaxCalculationHandler.HandleTax(grossAnnualSalary);

            // Assert
            result.Should().Be(grossAnnualSalary * taxRate/100);
        }

        [Theory]
        [InlineData(73)]
        [InlineData(25)]
        [InlineData(10)]
        public void TaxBand_CheckTaxRateCorrectness_ReturnsDividedBy100(decimal taxRate)
        {
            // Arrange

            TaxBandCalculationHandler bandATaxCalculationHandler = new TaxBandCalculationHandler(new TaxBand(taxRate, 0, 0));

            // Act
            var result = bandATaxCalculationHandler.TaxBand.TaxRate;

            // Assert
            result.Should().Be(taxRate / 100);
        }

        [Theory]
        [InlineData(73, 20000, 20000, 29200)]
        [InlineData(25, 40000, 40001, 20000.25)]
        [InlineData(10, 10000, 10500, 2050)]
        public void HandleTax_PassTaxRateAndSalaryValueAboveUpperLimit_ReturnsCorrectTaxValue(
            decimal taxRate, 
            int upperTaxLimit, 
            decimal grossAnnualSalary,
            decimal expectedResult)
        {
            // Arrange
            TaxBandCalculationHandler bandATaxCalculationHandler = new TaxBandCalculationHandler(new TaxBand(taxRate, 0, upperTaxLimit));
            bandATaxCalculationHandler.SetTaxBandHandler(bandATaxCalculationHandler);

            // Act
            var result = bandATaxCalculationHandler.HandleTax(grossAnnualSalary);

            // Assert
            result.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(-1)]
        public void HandleTax_PassNegativeSalaryValue_ThrowsException(decimal grossAnnualValue)
        {
            // Arrange
            TaxBandCalculationHandler bandATaxCalculationHandler = new TaxBandCalculationHandler(new TaxBand(0, 0, 0));

            // Act
            Action action = () => bandATaxCalculationHandler.HandleTax(grossAnnualValue);

            // Assert
            action
                .Should()
                .Throw<UnsupportedValueException>()
                .WithMessage($"Can not calculate tax for {grossAnnualValue}. Please enter only numeric value.");
        }
    }
}
