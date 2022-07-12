using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace OrderNow.API.Services.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(Guid userId, string firstname, string lastname);
    }
}