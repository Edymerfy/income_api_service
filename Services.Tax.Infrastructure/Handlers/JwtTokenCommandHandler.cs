using MediatR;
using Services.Tax.Domain.Commands;
using Services.Tax.Infrastructure.Security;

namespace Services.Tax.Infrastructure.Handlers
{
    public class JwtTokenCommandHandler : IRequestHandler<GenerateJwtTokenUserQry, string?>
    {
        private readonly JwtTokenManager _jwtTokenManager;

        public JwtTokenCommandHandler(JwtTokenManager jwtTokenManager)
        {
            _jwtTokenManager = jwtTokenManager;
        }

        public Task<string?> Handle(GenerateJwtTokenUserQry request, CancellationToken cancellationToken)
        {
            string? jwtToken = null;

            if (request.UserName == "admin" && request.Password == "password")
            {
                jwtToken = _jwtTokenManager.GenerateJwtToken(request.UserName);
            }

            return Task.FromResult(jwtToken);
        }
    }
}
