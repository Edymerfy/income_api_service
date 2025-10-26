using MediatR;
using Services.Tax.Domain.Commands;
using Services.Tax.Infrastructure.DataAccess;
using Services.Tax.Infrastructure.Interfaces;

namespace Services.Tax.Infrastructure.Handlers
{
    public class TaxCommandHandler : IRequestHandler<CalculateIncomeTaxQry, IncomeTaxSummaryResult>
    {
        private const int Precision = 2;
        private readonly ITaxCalculator _taxCalculator;
        private readonly IPeriodRepository _periodRepository;

        public TaxCommandHandler(ITaxCalculator taxCalculator, IPeriodRepository periodRepository)
        {
            _taxCalculator = taxCalculator ?? throw new ArgumentNullException(nameof(taxCalculator));
            _periodRepository = periodRepository ?? throw new ArgumentNullException(nameof(periodRepository));
        }

        public async Task<IncomeTaxSummaryResult> Handle(CalculateIncomeTaxQry request, CancellationToken cancellationToken)
        {
            decimal tax = _taxCalculator.Calculate(request.Income);

            var period = await _periodRepository.GetByIdAsync((int)request.PeriodSplit);

            ArgumentNullException.ThrowIfNull(period);

            IncomeTaxSummaryResult incomeTaxSummary = new IncomeTaxSummaryResult
            {
                GrossAnnualSalary = Math.Round(request.Income, Precision),
                GrossMonthlySalary = Math.Round(request.Income / period.SplitValue, Precision),
                NetAnnualSalary = Math.Round(request.Income - tax, Precision),
                NetMonthlySalary = Math.Round((request.Income - tax) / period.SplitValue, Precision),
                AnnualTaxPaid = Math.Round(tax, Precision),
                MonthlyTaxPaid = Math.Round(tax / period.SplitValue, Precision)
            };

            return incomeTaxSummary;
        }
    }
}
