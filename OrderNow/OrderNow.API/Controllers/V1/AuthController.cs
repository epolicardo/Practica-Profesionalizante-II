using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using OrderNow.API.Services.Authentication;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mime;
using System.Security.Claims;
using System.Text.Json;

namespace OrderNow.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AuthController : ControllerBase
    {

        private readonly UserManager<Users> _userManager;
        private readonly IGenericRepository<Users> genericRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthController(UserManager<Users> userManager, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userManager = userManager;
            _jwtTokenGenerator = jwtTokenGenerator;
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
            //return Ok(new { Message = "User Registration Successful" });
        }

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

            var userId = Guid.NewGuid();
            var token = _jwtTokenGenerator.GenerateToken(userId, "Emiliano", "Policardo");
            Log.Information("Token granted to {@Email}", identityUser.Email);
            authorizationResult = new AuthenticationResult()
            {
                Token = token,
                Name = "Emiliano",
                LastName = "Policardo",
                Id = userId,
                Email = identityUser.Email
            };
            return Ok(authorizationResult);
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
            var userId = Guid.NewGuid();
            var token = _jwtTokenGenerator.GenerateToken(userId, credentials.email, credentials.Password);
            Log.Information("Token granted to {@Email}", identityUser.Email);
            

            authorizationResult = new AuthenticationResult()
            {
                Token = token,
                Name = "Emiliano",
                LastName = "Policardo",
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





        private async Task<Users> ValidateUser(LoginCredentials credentials)
        {
            var identityUser = await _userManager.FindByEmailAsync(credentials.email);

            if (identityUser != null)
            {
                var result = _userManager.PasswordHasher.VerifyHashedPassword(identityUser, identityUser.PasswordHash, credentials.Password);
                return result == PasswordVerificationResult.Failed ? null : identityUser;
            }

            //TODO: Corregir devolucion
            return null;
        }



    }

}

