namespace Services.Tax.Infrastructure.Interfaces
{
    public interface ITaxBandStrategy 
    { 
        public decimal Rate { get; }

        public Func<decimal, bool> Condition { get; }

        public decimal ExtractChunk(decimal amount);
    }
}
