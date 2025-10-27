using Services.Tax.Infrastructure.Interfaces;

namespace Services.Tax.Infrastructure.Utils
{
    public class IncomeTaxCalculator : ITaxCalculator
    {
        private readonly IEnumerable<ITaxBandStrategy> _taskBandStrategies;

        public IncomeTaxCalculator(IEnumerable<ITaxBandStrategy> taskBandStrategies)
        {
            _taskBandStrategies = taskBandStrategies;
        }

        public decimal Calculate(decimal amount)
        {
            var tax = 0m;

            foreach (var strategy in _taskBandStrategies) 
            {
                if (strategy.Condition(amount))
                {
                    var chunk = strategy.ExtractChunk(amount);
                    tax += chunk * strategy.Rate;
                }
            }

            return tax;
        }
    }
}
