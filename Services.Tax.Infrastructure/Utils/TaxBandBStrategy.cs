using Services.Tax.Infrastructure.Interfaces;

namespace Services.Tax.Infrastructure.Utils
{
    public class TaxBandBStrategy : ITaxBandStrategy
    {
        private const decimal MinRange = 5000M;
        private const decimal MaxRange = 20000M;

        public Func<decimal, bool> Condition => delegate (decimal income) { return income > MinRange; };

        public decimal Rate => 0.2M;

        public decimal ExtractChunk(decimal amount) => Math.Min(amount, MaxRange) - MinRange;
    }
}
