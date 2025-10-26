using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Services.Tax.Domain.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Services.Tax.Infrastructure.Security
{
    public class JwtTokenManager
    {
        private readonly SecurityOptions _securityOptions;

        public JwtTokenManager(IOptions<SecurityOptions> securityOptions)
        {
            _securityOptions = securityOptions.Value;
        }

        public string GenerateJwtToken(string username)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_securityOptions.JwtSecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
