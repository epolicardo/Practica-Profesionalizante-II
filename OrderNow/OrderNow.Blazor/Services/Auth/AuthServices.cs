using Services;

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

        public AuthResult Login(LoginRequest request)
        {
            throw new NotImplementedException();
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

        //public AuthResult Login(LoginRequest request)
        //{
        //    //Log.Information("User ingresado: {@Credenciales}", credentials.email);
        //    //Users identityUser;
        //    //AuthResult authorizationResult;

        //    //if (!ModelState.IsValid
        //    //    || credentials == null
        //    //    || (identityUser = await ValidateUser(credentials)) == null)
        //    //{
        //    //    authorizationResult = new AuthResult()
        //    //    {
        //    //        Token = "Not Generated",
        //    //        Email = credentials.email
        //    //    };
        //    //    return BadRequest(authorizationResult);
        //    //}

        //    //var userId = Guid.Parse(identityUser.Id);
        //    //var token = _jwtTokenGenerator.GenerateToken(userId, "Emiliano", "Policardo");
        //    //Log.Information("Token granted to {@Email}", identityUser.Email);
        //    //authorizationResult = new AuthResult()
        //    //{
        //    //    Token = token,
        //    //    Name = identityUser.person.FirstName,
        //    //    LastName = identityUser.person.LastName,
        //    //    Id = userId,
        //    //    Email = identityUser.Email
        //    //};
        //    //return Ok(authorizationResult);
        //}

        AuthResult IAuthServices.RegisterAsync(RegisterRequest request)
        {
            throw new NotImplementedException();
        }
    }
}