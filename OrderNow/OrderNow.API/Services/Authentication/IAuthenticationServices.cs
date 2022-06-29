namespace OrderNow.API.Services.Authentication
{
    public interface IAuthenticationServices
    {
        AuthenticationResult Login(LoginRequest request);
        AuthenticationResult Register(RegisterRequest request);
    }
}
