using Services.Tax.Infrastructure.Interfaces;

namespace Services.Tax.Infrastructure.Utils
{
    public class IncomeTaxCalculator : ITaxCalculator
    {
        private const decimal PersonalAllowance = 5000;
        private const decimal HigherRateLimit = 20000;

        private const decimal BasicRate = 0.20m;
        private const decimal HigherRate = 0.40m;

        public decimal Calculate(decimal amount)
        {
            decimal tax;

            if (amount <= PersonalAllowance)
                tax = 0;

            else if (amount <= HigherRateLimit)
                tax = (amount - PersonalAllowance) * BasicRate;
            else
            {
                decimal basicTax = (HigherRateLimit - PersonalAllowance) * BasicRate;
                decimal higherTax = (amount - HigherRateLimit) * HigherRate;

                tax = basicTax + higherTax;
            }

            return tax;
        }
    }
}
