using System.ComponentModel.DataAnnotations;

namespace Services.Tax.Domain.Api
{
    public record IncomeTaxRequest
    {
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Income value is invalid")]
        public decimal Income { get; init; }
    }
}
