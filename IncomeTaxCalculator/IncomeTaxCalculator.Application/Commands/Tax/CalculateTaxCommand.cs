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
        private IMonthlyTaxCalculator _monthlyTaxCalculator;

        public CalculateTaxCommandHandler(IAnnualTaxCalculator annualTaxCalculator, IMonthlyTaxCalculator monthlyTaxCalculator)
        {
            _annualTaxCalculator = annualTaxCalculator;
            _monthlyTaxCalculator = monthlyTaxCalculator;
        }
        public async Task<TaxResult> Handle(CalculateTaxCommand request, CancellationToken cancellationToken)
        {
            var annualTaxPaid = await _annualTaxCalculator.CalculateAnnualTaxPaid(request.GrossAnnualSalary);
            var netAnnualSalary = await _annualTaxCalculator.CalculateNetAnnualSalary(request.GrossAnnualSalary, annualTaxPaid);
            var netMonthlySalary = await _monthlyTaxCalculator.CalculateNetMonthlySalary(netAnnualSalary);
            var grossMonthlySalary = await _monthlyTaxCalculator.CalculateGrossMonthlySalary(request.GrossAnnualSalary);
            var monthlyTaxPaid = await _monthlyTaxCalculator.CalculateMonthlyTaxPaid(annualTaxPaid);
            return new TaxResult
            {
                AnnualTaxPaid = annualTaxPaid,
                GrossAnnualSalary = request.GrossAnnualSalary,
                NetAnnualSalary = netAnnualSalary,
                GrossMonthlySalary = grossMonthlySalary,
                NetMonthlySalary = netMonthlySalary,
                MonthlyTaxPaid = monthlyTaxPaid
            };
        }
    }
}
