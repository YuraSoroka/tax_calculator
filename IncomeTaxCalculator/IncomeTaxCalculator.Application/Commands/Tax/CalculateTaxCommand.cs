using IncomeTaxCalculator.Application.Common.Interfaces;
using IncomeTaxCalculator.Domain.Entities;
using MediatR;

namespace IncomeTaxCalculator.Application.Commands.Tax
{
    public class CalculateTaxCommand : IRequest<TaxResult>
    {
        public int GrossAnnualSalary { get; set; }
    }

    public class CalculateTaxCommandHandler : IRequestHandler<CalculateTaxCommand, TaxResult>
    {
        private ITaxCalculator _taxCalculator;
        public CalculateTaxCommandHandler(ITaxCalculator taxCalculator)
        {
            _taxCalculator = taxCalculator;
        }
        public async Task<TaxResult> Handle(CalculateTaxCommand request, CancellationToken cancellationToken)
        {
            return await _taxCalculator.CalculateTax(request.GrossAnnualSalary);
        }
    }
}
