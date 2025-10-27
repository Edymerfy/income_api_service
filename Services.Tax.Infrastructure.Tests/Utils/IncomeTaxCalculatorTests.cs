using Services.Tax.Infrastructure.Interfaces;
using Services.Tax.Infrastructure.Utils;

namespace Services.Tax.Infrastructure.Tests.Utils
{
    public class IncomeTaxCalculatorTests
    {
        private readonly IncomeTaxCalculator _calculator =
            new IncomeTaxCalculator(new List<ITaxBandStrategy>()
            {
                new TaxBandAStrategy(),
                new TaxBandBStrategy(),
                new TaxBandCStrategy(),
            });

        [Theory]
        [InlineData(0, 0)]
        [InlineData(3000, 0)]
        [InlineData(5000, 0)]
        [InlineData(10000, 1000)]
        [InlineData(20000, 3000)]
        [InlineData(30000, 7000)]
        [InlineData(50000, 15000)]
        public void Calculate_ReturnsExpectedTax(decimal income, decimal expectedTax)
        {
            var result = _calculator.Calculate(income); 

            Assert.Equal(expectedTax, result);
        }
    }
}
