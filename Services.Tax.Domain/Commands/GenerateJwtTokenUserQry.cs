using MediatR;

namespace Services.Tax.Domain.Commands
{
    public record GenerateJwtTokenUserQry : IRequest<string?>
    {
        public required string UserName { get; init; }

        public required string Password { get; init; }
    }
}
