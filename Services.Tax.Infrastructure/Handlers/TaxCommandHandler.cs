using MediatR;
using Services.Tax.Domain.Commands;
using Services.Tax.Infrastructure.Interfaces;

namespace Services.Tax.Infrastructure.Handlers
{
    public class TaxCommandHandler : IRequestHandler<CalculateIncomeTaxQry, IncomeTaxSummaryResult>
    {
        private const int Precision = 2;
        private readonly ITaxCalculator _taxCalculator;

        public TaxCommandHandler(ITaxCalculator taxCalculator)
        {
            _taxCalculator = taxCalculator ?? throw new ArgumentNullException(nameof(taxCalculator));
        }

        public Task<IncomeTaxSummaryResult> Handle(CalculateIncomeTaxQry request, CancellationToken cancellationToken)
        {
            decimal tax = _taxCalculator.Calculate(request.Income);

            int splitter = (int)request.PeriodSplit;

            IncomeTaxSummaryResult incomeTaxSummary = new IncomeTaxSummaryResult
            {
                GrossAnnualSalary = Math.Round(request.Income, Precision),
                GrossMonthlySalary = Math.Round(request.Income / splitter, Precision),
                NetAnnualSalary = Math.Round(request.Income - tax, Precision),
                NetMonthlySalary = Math.Round((request.Income - tax) / splitter, Precision),
                AnnualTaxPaid = Math.Round(tax, Precision),
                MonthlyTaxPaid = Math.Round(tax / splitter, Precision)
            };

            return Task.FromResult(incomeTaxSummary);
        }
    }
}
