using MediatR;

namespace Services.Tax.Domain.Commands
{
    public record CalculateIncomeTaxQry : IRequest<IncomeTaxSummaryResult>
    {
        public decimal Income { get; init; }

        public PeriodSplit PeriodSplit { get; init; }
    }
}
