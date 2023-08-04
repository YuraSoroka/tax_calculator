using IncomeTaxCalculator.Application.Common.Helpers;
using IncomeTaxCalculator.Application.Common.Interfaces;
using IncomeTaxCalculator.Domain.Entities;
using MediatR;

namespace IncomeTaxCalculator.Application.Commands.Tax
{
    public class CalculateTaxCommand : IRequest<TaxResult>
    {
        public decimal GrossAnnualSalary { get; set; }
    }

    public class CalculateTaxCommandHandler : IRequestHandler<CalculateTaxCommand, TaxResult>
    {
        private IAnnualTaxCalculator _annualTaxCalculator;

        public CalculateTaxCommandHandler(IAnnualTaxCalculator annualTaxCalculator)
        {
            _annualTaxCalculator = annualTaxCalculator;
        }
        public async Task<TaxResult> Handle(CalculateTaxCommand request, CancellationToken cancellationToken)
        {
            var annualTaxPaid = await _annualTaxCalculator.CalculateAnnualTaxPaid(request.GrossAnnualSalary);
            var netAnnualSalary = await _annualTaxCalculator.CalculateNetAnnualSalary(request.GrossAnnualSalary, annualTaxPaid);
            return new TaxResult
            {
                GrossAnnualSalary = request.GrossAnnualSalary,
                GrossMonthlySalary = request.GrossAnnualSalary.GetMonthlyValue(),
                AnnualTaxPaid = annualTaxPaid,
                MonthlyTaxPaid = annualTaxPaid.GetMonthlyValue(),
                NetAnnualSalary = netAnnualSalary,
                NetMonthlySalary = netAnnualSalary.GetMonthlyValue(),
            };
        }
    }
}
