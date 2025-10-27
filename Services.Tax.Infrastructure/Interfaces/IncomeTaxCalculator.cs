using Services.Tax.Infrastructure.Utils;

namespace Services.Tax.Infrastructure.Interfaces
{
    public class IncomeTaxCalculator : ITaxCalculator
    {
        private readonly IEnumerable<ITaskBandStrategy> _taskBandStrategies;

        public IncomeTaxCalculator(IEnumerable<ITaskBandStrategy> taskBandStrategies)
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
