namespace OrderNow.API.Services.Authentication
{
    public class AuthenticationServices : IAuthenticationServices
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthenticationResult Register(RegisterRequest request)
        {
            //Check if user already exists

            //Create user

            //Create JWT Token
            throw new NotImplementedException();
        }

        public AuthenticationResult Login(LoginRequest request)
        {
            throw new NotImplementedException();
        }
    }
}