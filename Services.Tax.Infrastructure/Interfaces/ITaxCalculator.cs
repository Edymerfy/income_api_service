namespace Services.Tax.Infrastructure.Interfaces
{
    public interface ITaxCalculator
    {
        public decimal Calculate(decimal amount);
    }
}
