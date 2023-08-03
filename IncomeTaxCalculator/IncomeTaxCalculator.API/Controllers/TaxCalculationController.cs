using IncomeTaxCalculator.Application.Commands.Tax;
using IncomeTaxCalculator.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace IncomeTaxCalculator.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxCalculationController : ApiControllerBase
    {
        [HttpPost("calculate")]
        public async Task<ActionResult<TaxResult>> CalculateTax(CalculateTaxCommand tax)
        {
            return await Mediator.Send(tax);
        }
    }
}
