namespace Services.Tax.Infrastructure.Utils
{
    public class TaskBandAStrategy : ITaskBandStrategy
    {
        private const decimal MaxRange = 5000M;

        public Func<decimal, bool> Condition => delegate (decimal income) { return income >= 0; };

        public decimal Rate => 0;

        public decimal ExtractChunk(decimal amount) => Math.Min(amount, MaxRange);
    }
}
