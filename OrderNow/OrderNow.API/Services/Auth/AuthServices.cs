using Microsoft.AspNetCore.Identity;
using System.Web.Mvc;

namespace OrderNow.API.Services.Auth
{
    public class AuthServices : IAuthServices
    {

        private readonly IJwtTokenGenerator _jwtTokenGenerator;
      
        private readonly IUsersServices _usersServices;


        public AuthServices(IUsersServices usersServices, IJwtTokenGenerator jwtTokenGenerator)
        {
            _usersServices = usersServices;
        
            _jwtTokenGenerator = jwtTokenGenerator;
        }
        public async Task<AuthResult> RegisterAsync(Users user)
        {
            //var result = await _usersServices.CreateAsync(request);
            //request.Password = _userServices.PasswordHasher.HashPassword(null, request.Password);

            //if (!result.Succeeded)
            //{
            //    var dictionary = new ModelStateDictionary();
            //    foreach (IdentityError error in result.Errors)
            //    {
            //        dictionary.AddModelError(error.Code, error.Description);
            //    }

            //    AuthResult authenticationResult = new AuthResult
            //    {
            //        Email = "User Registration Failed"
            //        //Errors = dictionary
            //    };
            //    return authenticationResult;
            //}
            return null;
            //return CreatedAtActionResult(nameof(RegisterAsync), new { id = user.Id }, user);
            //Check if user already exists

            //Create user

            //Create JWT Token
          
        }

        public AuthResult Login(LoginRequest request)
        {
            throw new NotImplementedException();
        }

        AuthResult IAuthServices.RegisterAsync(RegisterRequest request)
        {
            throw new NotImplementedException();
        }
    }
}