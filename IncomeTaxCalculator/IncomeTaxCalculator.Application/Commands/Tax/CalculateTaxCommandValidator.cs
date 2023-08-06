
using FluentValidation;

namespace IncomeTaxCalculator.Application.Commands.Tax
{
    public class CalculateTaxCommandValidator : AbstractValidator<CalculateTaxCommand>
    {
        public CalculateTaxCommandValidator()
        {
            RuleFor(v => v.GrossAnnualSalary)
                .GreaterThanOrEqualTo(0)
                .NotNull();
        }
    }
}
