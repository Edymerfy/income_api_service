using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Tax.Domain.Api;
using Services.Tax.Domain.Commands;

namespace Services.Tax.Api.Controllers
{
    [Route("api/[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CalculatorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("income")]
        public async Task<IActionResult> CalculateIncomeTax([FromBody] IncomeTaxRequest request)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                return BadRequest(GeneralResponse<object>.FailResponse(errors));
            }

            var data = await _mediator.Send(new CalculateIncomeTaxQry
            {
                Income = request.Income,
                PeriodSplit = Domain.PeriodSplit.PerMonth
            });

            return Ok(GeneralResponse<IncomeTaxSummaryResult>.SuccessResponse(data));
        }
    }
}
