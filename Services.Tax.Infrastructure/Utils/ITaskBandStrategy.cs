namespace Services.Tax.Infrastructure.Utils
{
    public interface ITaskBandStrategy 
    { 
        public decimal Rate { get; }

        public Func<decimal, bool> Condition { get; }

        public decimal ExtractChunk(decimal amount);
    }
}
