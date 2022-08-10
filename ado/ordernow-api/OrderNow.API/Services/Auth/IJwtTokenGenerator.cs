using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace OrderNow.API.Services.Auth
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(Guid userId, string firstname, string lastname);
    }
}