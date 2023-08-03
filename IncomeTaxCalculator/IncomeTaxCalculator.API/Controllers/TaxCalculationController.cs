using Microsoft.AspNetCore.Mvc;

namespace IncomeTaxCalculator.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxCalculationController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> CalculateTax()
        {
            return Ok();
        }
    }
}
