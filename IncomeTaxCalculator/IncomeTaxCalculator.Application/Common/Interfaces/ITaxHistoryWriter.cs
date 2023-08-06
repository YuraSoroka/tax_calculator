using IncomeTaxCalculator.Domain.Entities;

namespace IncomeTaxCalculator.Application.Common.Interfaces
{
    public interface ITaxHistoryWriter
    {
        Task<int> WriteTaxResultHistory(TaxResult taxResult);
    }
}
