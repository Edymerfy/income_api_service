using MediatR;
using Microsoft.AspNetCore.Authorization;
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

        /// <summary>
        /// Calculates income tax for a given annual income.
        /// </summary>
        /// <param name="request">Annual income request.</param>
        /// <returns>Calculated income tax summary result.</returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GeneralResponse<IncomeTaxSummaryResult>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("income")]
        [Authorize]
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
