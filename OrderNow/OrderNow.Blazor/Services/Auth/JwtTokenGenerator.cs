using Microsoft.IdentityModel.Tokens;
using OrderNow.API.Services.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace OrderNow.Common.Services.Auth
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly JwtBearerTokenSettings _jwtSettings;

        private readonly IDateTimeProvider _dateTimeProvider;

        public JwtTokenGenerator(IDateTimeProvider dateTimeProvider,
            IOptions<JwtBearerTokenSettings> jwtSettings)
        {
            _dateTimeProvider = dateTimeProvider;
            _jwtSettings = jwtSettings.Value;
        }

        public string GenerateToken(Guid userId, string firstname, string lastname)
        {
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_jwtSettings.SecretKey)),
                SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, firstname),
                new Claim(JwtRegisteredClaimNames.FamilyName, lastname),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var securityToken = new JwtSecurityToken(
            audience: _jwtSettings.Audience,
            issuer: _jwtSettings.Issuer,
            expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpiryTimeInMinutes),
            signingCredentials: signingCredentials,
            claims: claims
            );

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}