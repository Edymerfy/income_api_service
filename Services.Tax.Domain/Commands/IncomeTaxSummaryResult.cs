namespace Services.Tax.Domain.Commands
{
    public record IncomeTaxSummaryResult
    {
        public decimal GrossAnnualSalary { get; init; }

        public decimal GrossMonthlySalary { get; init; }

        public decimal NetAnnualSalary { get; init; }

        public decimal NetMonthlySalary { get; init; }

        public decimal AnnualTaxPaid { get; init; }

        public decimal MonthlyTaxPaid { get; init; }
    }
}
