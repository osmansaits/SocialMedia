using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Utilities
{
    public class JwtManager : IJwtService
    {
        private readonly IConfiguration _configuration;
        private readonly string _salt;
        public JwtManager(IConfiguration configuration)
        {
            _configuration = configuration;
            _salt = _configuration["JwtSettings:Salt"];
        }
        public string GenerateJwtToken(string authMail)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])); //Güvenlik anahtarı
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);           //Şifreleme yöntemi
            var claims = new[]
            {
                new Claim (ClaimTypes.Email, authMail)
            };

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Issuer"], claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials

                );
            return new JwtSecurityTokenHandler().WriteToken(token);


        }

        public Guid? ValidateToken(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_salt);

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = _configuration["Jtw:Issuer"],
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateLifetime = true,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userIdString = jwtToken.Claims.FirstOrDefault(c => c.Type == "id")?.Value;

                if (Guid.TryParse(userIdString, out var userId))
                {
                    return userId;
                }

                return null;

            }

            catch
            {
                return null;
            }

        }
    }
}
