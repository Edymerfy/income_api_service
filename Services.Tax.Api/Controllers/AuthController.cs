using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Tax.Domain.Api;
using Services.Tax.Domain.Commands;

namespace Services.Tax.Api.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));  
        }

        /// <summary>
        /// Authenticates a user with the provided credentials and returns a JWT token if successful.
        /// </summary>
        /// <param name="request">User login credentials (username and password).</param>
        /// <returns>
        /// Returns a JSON Web Token (JWT) if authentication succeeds.
        /// </returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GeneralResponse<string>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                return BadRequest(GeneralResponse<object>.FailResponse(errors));
            }

            var jwt = await _mediator.Send(new GenerateJwtTokenUserQry { UserName = request.UserName, Password = request.Password });

            return (jwt is null) ? Unauthorized() : Ok(GeneralResponse<string>.SuccessResponse(jwt));
        }
    }
}
