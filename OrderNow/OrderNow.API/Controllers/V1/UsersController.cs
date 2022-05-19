

using Data.Entities;
using Hangfire;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.IdentityModel.Tokens;
using Serilog.Core;
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
        private readonly UserManager<Users> userManager;
        private readonly DataContext context;
        private readonly IGenericRepository<Users> genericRepository;
        
        //private readonly IConfigurationHelper configHelper;

        public UsersController(IOptions<JwtBearerTokenSettings> jwtTokenOptions, UserManager<Users> userManager, DataContext _context,
            IGenericRepository<Users> _genericRepository)
        {
            this.jwtBearerTokenSettings = jwtTokenOptions.Value;
            this.userManager = userManager;
            context = _context;
            genericRepository = _genericRepository;
          

        }

        [Authorize]
        [HttpGet]
        [Route("GetByMailAsync/{email}")]
        public IdentityUser GetByMailAsync(string email)
        {
      
            return context.Users.FirstOrDefault(u=> u.Email == email);
            //return context.Users.Include(p => p.Person).ThenInclude(d => d.Domicilio).FirstOrDefault(x => x.Email == email);

        }


        [Authorize]
        [HttpGet]
        [Route("GetByIdAsync")]
        public async Task<Users> GetByIdAsync(string Id)
        {
              return await genericRepository.GetByIdAsync(Id);
                    }



        [HttpGet]
        [Route("GetList")]
        public IEnumerable<Users> GetList()
        {

            LogContext.PushProperty("Metodo", MethodBase.GetCurrentMethod());
            LogContext.PushProperty("Server", Environment.MachineName);
            IEnumerable<Users> Users = null;
            try
            {

                Users = (IEnumerable<Users>?)context.Users.ToList();
                Log.Information("Users: {@Users}", Users);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Sucedio un error");
            }
            return Users;
        }

        [Authorize]
        [HttpGet]
        [Route("GetListByGroup")]
        public IEnumerable<Users> GetListByGroup(string TituloGrupo)
        {
            LogContext.PushProperty("Metodo", MethodBase.GetCurrentMethod());
            LogContext.PushProperty("Server", Environment.MachineName);
            IEnumerable<Users> Users = (IEnumerable<Users>)context.Users.ToList();
            //IEnumerable<Users> Users = context.Users.Include(x => x.Persona).Where(x => x.Persona.Apellido == TituloGrupo).ToList();
            Log.Information("Users: {@Users}", Users);
            return Users;

        }



        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(Users user)
        {
            if (!ModelState.IsValid || user == null)
            {
                return new BadRequestObjectResult(new { Message = "User Registration Failed" });
            }
          
            user.UserType = UserType.User;
            var result = await userManager.CreateAsync(user);
            
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
            Log.Information("Users ingresado: {@Credenciales}", credentials.Username);
            IdentityUser identityUser;

            if (!ModelState.IsValid
                || credentials == null
                || (identityUser = await ValidateUser(credentials)) == null)
            {
                return new BadRequestObjectResult(new { Token = "Not Generated", Message = "Error", Email = credentials.Username });
            }

            var token = GenerateToken(identityUser);
            Log.Information("Token granted to {@Email}", identityUser.Email);
            return Ok(new { Token = token, Message = "Success", Email = identityUser.Email });
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

        [HttpGet]
        [Route("CreateJob")]
        public void CreateJob()
        {
            BackgroundJob.Enqueue(() => Console.WriteLine("Ejecutar algo luego de la creacion de un usuario"));
           
            Log.Information("Se ha creado el job");
          
            BackgroundJob.Enqueue<IEmailSender>(x =>
            x.SendEmail(
               "emilianopolicardo@gmail.com",
               "hangfire@example.com",
               "Hola Mundo Loco",
               "Hola mundo"));

        }
    }
}
