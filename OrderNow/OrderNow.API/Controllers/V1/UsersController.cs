using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
 

    public class UsersController : ControllerBase
    {

        private readonly JwtBearerTokenSettings jwtBearerTokenSettings;
        private readonly UserManager<IdentityUser> userManager;
        private readonly DataContext context;
        private readonly IGenericRepository<User> genericRepository;

        //private readonly IConfigurationHelper configHelper;

        public UsersController(IOptions<JwtBearerTokenSettings> jwtTokenOptions, UserManager<IdentityUser> userManager, DataContext _context,
            IGenericRepository<User> _genericRepository)
        {
            this.jwtBearerTokenSettings = jwtTokenOptions.Value;
            this.userManager = userManager;
            context = _context;
            genericRepository = _genericRepository;


        }

       
        [HttpPost]
        [Route("GetByMailAsync/{email}")]
        public User GetByMailAsync(string email)
        {



            return context.User.FirstOrDefault(u => u.Email == email);
            //return context.Users.Include(p => p.Person).ThenInclude(d => d.Domicilio).FirstOrDefault(x => x.Email == email);

        }

     //   [Authorize(Policy = "GetToken")]
        [Authorize]
        [HttpGet]
        [Route("GetByIdAsync")]
        public async Task<User> GetByIdAsync(string Id)
        {
            return await genericRepository.GetByIdAsync(Id);
        }


        
        [HttpGet]
        [Route("GetList")]
        public IEnumerable<User> GetList()
        {

            LogContext.PushProperty("Metodo", MethodBase.GetCurrentMethod());
            LogContext.PushProperty("Server", Environment.MachineName);
            IEnumerable<User> User= null;
            try
            {

                User = context.User.Include(p=>p.person).ToList();
                Log.Information("Users: {@Users}", User);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Sucedio un error");
            }
            return User;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("GetListByGroup")]
        public IEnumerable<User> GetListByGroup(string TituloGrupo)
        {
            LogContext.PushProperty("Metodo", MethodBase.GetCurrentMethod());
            LogContext.PushProperty("Server", Environment.MachineName);
            IEnumerable<User> Users = (IEnumerable<User>)context.Users.ToList();
            //IEnumerable<Users> Users = context.Users.Include(x => x.Persona).Where(x => x.Persona.Apellido == TituloGrupo).ToList();
            Log.Information("Users: {@Users}", Users);
            return Users;

        }


        [AllowAnonymous]
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(User user)
        {
            if (!ModelState.IsValid || user == null)
            {
                return new BadRequestObjectResult(new { Message = "User Registration Failed" });
            }

            var result = await userManager.CreateAsync(user, user.Password);
            user.Password = userManager.PasswordHasher.HashPassword(user, user.Password);
            

            if (!result.Succeeded)
            {
                var dictionary = new ModelStateDictionary();
                foreach (IdentityError error in result.Errors)
                {
                    dictionary.AddModelError(error.Code, error.Description);
                }

                return new BadRequestObjectResult(new { Message = "User Registration Failed", Errors = dictionary });
            }
            await context.SaveChangesAsync();


            return Ok(new { Message = "User Registration Successful" });
        }


        [HttpPost]
        [Route("GetToken")]
        public async Task<IActionResult> GetToken(LoginCredentials credentials)
        {
            Log.Information("User ingresado: {@Credenciales}", credentials.Username);
            IdentityUser identityUser;

            if (!ModelState.IsValid
                || credentials == null
                || (identityUser = await ValidateUser(credentials)) == null)
            {
                return new BadRequestObjectResult(
                    new
                    {
                        Token = "Not Generated",
                        Message = "Error",
                        Email = credentials.Username
                    });
            }

            var token = GenerateToken(identityUser);
            Log.Information("Token granted to {@Email}", identityUser.Email);
            return Ok(new
            {
                Token = token,
                Message = "Success",
                Email = identityUser.Email,
            });
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

        private async Task<IdentityUser> ValidateUser(LoginCredentials credentials)
        {
            var identityUser = await userManager.FindByNameAsync(credentials.Username);
            if (identityUser != null)
            {
                var result = userManager.PasswordHasher.VerifyHashedPassword(identityUser, identityUser.PasswordHash, credentials.Password);
                return result == PasswordVerificationResult.Failed ? null : identityUser;
            }


            //TODO: Corregir devolucion
            return null;
        }


        private object GenerateToken(IdentityUser identityUser)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtBearerTokenSettings.SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, identityUser.UserName.ToString()),
                    new Claim(ClaimTypes.Email, identityUser.Email)
                }),

                Expires = DateTime.UtcNow.AddSeconds(jwtBearerTokenSettings.ExpiryTimeInSeconds),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Audience = jwtBearerTokenSettings.Audience,
                Issuer = jwtBearerTokenSettings.Issuer
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
