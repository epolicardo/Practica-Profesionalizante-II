using Microsoft.AspNetCore.Mvc.ModelBinding;
using OrderNow.API.Filters;
using OrderNow.API.Services.Authentication;
using System.Net.Mime;

namespace OrderNow.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly UserManager<Users> _userManager;
        private readonly IUsersServices _usersServices;

        public AuthController(UserManager<Users> userManager, IJwtTokenGenerator jwtTokenGenerator, IUsersServices usersServices)
        {
            _userManager = userManager;
            _jwtTokenGenerator = jwtTokenGenerator;
            _usersServices = usersServices;
        }

        //Generar PDF desde HTML
        // https://stackoverflow.com/questions/49808434/generating-pdf-from-json-and-json-schema


   
        [EmailAddressFilter("Metodo Login")]
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginCredentials credentials)
        {
            Log.Information("User ingresado: {@Credenciales}", credentials.email);
            Users identityUser;
            AuthenticationResult authorizationResult;

            if (!ModelState.IsValid
                || credentials == null
                || (identityUser = await ValidateUser(credentials)) == null)
            {
                authorizationResult = new AuthenticationResult()
                {
                    Token = "Not Generated",
                    Email = credentials.email
                };
                return BadRequest(authorizationResult);
            }

            var userId = Guid.Parse(identityUser.Id);
            var token = _jwtTokenGenerator.GenerateToken(userId, "Emiliano", "Policardo");
            Log.Information("Token granted to {@Email}", identityUser.Email);
            authorizationResult = new AuthenticationResult()
            {
                Token = token,
                Name = identityUser.person.FirstName,
                LastName = identityUser.person.LastName,
                Id = userId,
                Email = identityUser.Email
            };
            return Ok(authorizationResult);
        }

        [HttpPost]
        [Route("Logout")]
        public IActionResult Logout()
        {
            // Well, What do you want to do here ?
            // Wait for token to get expired OR
            // Maintain token cache and invalidate the tokens after logout method is called
            return Ok(new { Token = "", Message = "Logged Out" });
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [AllowAnonymous]
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(Users user)
        {
            if (!ModelState.IsValid || user == null)
            {
                return new BadRequestObjectResult(new { Message = "User Registration Failed" });
            }

            var result = await _userManager.CreateAsync(user, user.Password);
            user.Password = _userManager.PasswordHasher.HashPassword(user, user.Password);

            if (!result.Succeeded)
            {
                var dictionary = new ModelStateDictionary();
                foreach (IdentityError error in result.Errors)
                {
                    dictionary.AddModelError(error.Code, error.Description);
                }

                return new BadRequestObjectResult(new { Message = "User Registration Failed", Errors = dictionary });
            }

            return CreatedAtAction(nameof(Register), new { id = user.Id }, user);

        }

        [HttpPost]
        [Route("Token")]
        public async Task<IActionResult> Token(LoginCredentials credentials)
        {
            Log.Information("User ingresado: {@Credenciales}", credentials.email);
            Users identityUser;
            AuthenticationResult authorizationResult;

            if (!ModelState.IsValid
                || credentials == null
                || (identityUser = await ValidateUser(credentials)) == null)
            {
                authorizationResult = new AuthenticationResult()
                {
                    Email = credentials.email,
                    Token = "Not generated"
                };
                return BadRequest(authorizationResult);
            }
            var userId = Guid.Parse(identityUser.Id);
            var token = _jwtTokenGenerator.GenerateToken(userId, credentials.email, credentials.Password);
            Log.Information("Token granted to {@Email}", identityUser.Email);

            authorizationResult = new AuthenticationResult()
            {
                Token = token,
                Name = identityUser.person.FirstName,
                LastName = identityUser.person.LastName,
                Id = userId,
                Email = identityUser.Email
            };
            return Ok(authorizationResult);
        }

        private async Task<Users> ValidateUser(LoginCredentials credentials)
        {
            //var identityUser = await _userManager.FindByEmailAsync(credentials.email);

            var user = _usersServices.GetByMailAsync(credentials.email);


            if (user != null)
            {
                var result = _userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, user.Password);
                return result == PasswordVerificationResult.Failed ? null : user;
            }

            //TODO: Corregir devolucion
            return null;
        }
    }
}