using IncomeTaxCalculator.Application.Commands.Tax;
using IncomeTaxCalculator.Application.Common.Interfaces;
using Moq;
using FluentAssertions;
using IncomeTaxCalculator.Domain.Entities;

namespace Application.UnitTests.Commands.Tax
{
    public class CalculateTaxCommandTest
    {
        private readonly Mock<IAnnualTaxCalculator> _annualTaxCalculatorMock;
        private readonly Mock<ITaxHistoryWriter> _taxHistoryWriter;

        public CalculateTaxCommandTest()
        {
            _annualTaxCalculatorMock = new();
            _taxHistoryWriter = new();
        }

        [Fact]
        public async Task CalculateTaxCommandHandler_ExecutesWithSalary_ReturnTaxResultObject()
        {
            // Arrange
            var command = new CalculateTaxCommand
            {
                GrossAnnualSalary = 40000
            };
            var handler = new CalculateTaxCommandHandler(_annualTaxCalculatorMock.Object, _taxHistoryWriter.Object);

            // Act
            var taxResult = await handler.Handle(command ,default);

            // assert
            taxResult.Should().NotBeNull();
            taxResult.Should().BeOfType<TaxResult>();
        }
    }
}
