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
        private readonly ITaxHistoryWriter _taxHistoryWriter;

        public CalculateTaxCommandHandler(IAnnualTaxCalculator annualTaxCalculator, ITaxHistoryWriter taxHistoryWriter)
        {
            _annualTaxCalculator = annualTaxCalculator;
            _taxHistoryWriter = taxHistoryWriter;
        }
        public async Task<TaxResult> Handle(CalculateTaxCommand request, CancellationToken cancellationToken)
        {
            var annualTaxPaid = await _annualTaxCalculator.CalculateAnnualTaxPaid(request.GrossAnnualSalary);
            var netAnnualSalary = await _annualTaxCalculator.CalculateNetAnnualSalary(request.GrossAnnualSalary, annualTaxPaid);
            TaxResult taxResult =  new TaxResult
            {
                GrossAnnualSalary = request.GrossAnnualSalary,
                GrossMonthlySalary = request.GrossAnnualSalary.GetMonthlyValue(),
                AnnualTaxPaid = annualTaxPaid,
                MonthlyTaxPaid = annualTaxPaid.GetMonthlyValue(),
                NetAnnualSalary = netAnnualSalary,
                NetMonthlySalary = netAnnualSalary.GetMonthlyValue(),
            };
            await _taxHistoryWriter.WriteTaxResultHistory(taxResult);
            return taxResult;
        }
    }
}
