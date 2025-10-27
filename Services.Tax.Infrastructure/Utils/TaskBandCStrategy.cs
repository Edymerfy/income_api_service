namespace Services.Tax.Infrastructure.Utils
{
    public class TaskBandCStrategy : ITaskBandStrategy
    {
        private const decimal MinRange = 20000M;

        public Func<decimal, bool> Condition => delegate (decimal income) { return income > MinRange; };

        public decimal Rate => 0.4M;

        public decimal ExtractChunk(decimal amount) => amount - MinRange;
    }
}
