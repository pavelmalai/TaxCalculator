using Commify.TaxCalculator.Core.Taxes;
using Microsoft.AspNetCore.Mvc;

namespace Commify.TaxCalculator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxCalculatorController : ControllerBase
    {
        private readonly ILogger<TaxCalculatorController> _logger;
        private readonly ITaxService _taxService;

        public TaxCalculatorController(ILogger<TaxCalculatorController> logger, ITaxService taxService)
        {
            _logger = logger;
            _taxService = taxService;
        }

        [HttpGet(Name = "CalculateTax")]
        public IActionResult CalculateTax(decimal grossAnualSalary)
        {
            if (grossAnualSalary < 0)
            {
                return BadRequest("The gross anual salary must by a positive value!");
            }

            var taxesCalculationResult = _taxService.CalculateTax(grossAnualSalary);

            return Ok(taxesCalculationResult);
        }
    }
}
