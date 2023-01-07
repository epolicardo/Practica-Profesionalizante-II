namespace OrderNow.API.Services.Auth
{
    public interface IAuthServices
    {
        AuthResult Login(LoginRequest request);

        AuthResult RegisterAsync(RegisterRequest request);
    }
}