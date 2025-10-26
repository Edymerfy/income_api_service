using Microsoft.AspNetCore.Mvc;
using Services.Tax.Domain.Api;

namespace Services.Tax.Api.Controllers
{
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        /// <summary>
        /// Used to check application health check.
        /// </summary>
        /// <returns>Health check status and time stamp.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GeneralResponse<object>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get()
        {
            return Ok(GeneralResponse<object>.SuccessResponse(new
            {
                Status = "Healthy",
                Timestamp = DateTime.UtcNow
            }));
        }
    }
}
