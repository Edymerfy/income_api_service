using Microsoft.AspNetCore.Mvc;
using Services.Tax.Domain.Api;

namespace Services.Tax.Api.Controllers
{
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        [HttpGet]
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
