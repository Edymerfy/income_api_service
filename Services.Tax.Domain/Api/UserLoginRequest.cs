using System.ComponentModel.DataAnnotations;

namespace Services.Tax.Domain.Api
{
    public record UserLoginRequest
    {
        [Required(ErrorMessage = "UserName is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "UserName must be between 3 and 15 characters.")]
        public required string UserName { get; init; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 20 characters.")]
        [DataType(DataType.Password)]
        public required string Password { get; init; }
    }
}
