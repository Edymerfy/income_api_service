namespace Services.Tax.Domain.Configuration
{
    public class SecurityOptions
    {
        public string JwtSecretKey { get; init; } = string.Empty;
    }
}
