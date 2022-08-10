using Microsoft.AspNetCore.Mvc.ModelBinding;
using OrderNow.API.Data;
using System.Net.Mail;
using System.Net.Mime;

namespace Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly JwtBearerTokenSettings _jwtBearerTokenSettings;
        //private readonly UserManager<Users> _userManager;
        private readonly DataContext _context;
        private readonly IGenericRepository<Users> _genericRepository;
        private readonly IUsersServices _usersServices;

        public UsersController(IOptions<JwtBearerTokenSettings> jwtTokenOptions, DataContext context,
            IGenericRepository<Users> genericRepository, IUsersServices usersServices)
        {
            _jwtBearerTokenSettings = jwtTokenOptions.Value;
            _context = context;
            _genericRepository = genericRepository;
            LogContext.PushProperty("Metodo", MethodBase.GetCurrentMethod());
            LogContext.PushProperty("Server", Environment.MachineName);
            _usersServices = usersServices;
        }

        [HttpPost]
        [Route("GetByMailAsync/{email}")]
        public Users GetByMailAsync(string email)
        {
            //return _context.Users.FirstOrDefault(u => u.Email == email);
            return _context.Users.Include(p => p.person).ThenInclude(d => d.Address).FirstOrDefault(x => x.Email == email);
        }

        //   [Authorize(Policy = "GetToken")]
        //TODO Revisar autenticacion
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = JwtBearerExt)]
        [HttpGet]
        [Route("GetByIdAsync")]
        public async Task<Users> GetByIdAsync(string Id)
        {
            return await _genericRepository.GetByIdAsync(Id);
        }

        [HttpGet]
        [Route("GetList")]
        public IEnumerable<Users> GetList()
        {
            IEnumerable<Users> User = null;
            try
            {
                User = _context.Users.Include(p => p.person).Include(f => f.FavoriteBusiness).Include(f => f.FavoriteProducts).ToList();
                Log.Information("Users: {@Users}", User);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Sucedio un error");
            }
            return User;
        }

        //TODO Investigar como manegar roles y claims
        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("GetListByGroup")]
        public IEnumerable<Users> GetListByGroup(string TituloGrupo)
        {
            LogContext.PushProperty("Metodo", MethodBase.GetCurrentMethod());
            LogContext.PushProperty("Server", Environment.MachineName);
            IEnumerable<Users> Users = (IEnumerable<Users>)_context.Users.ToList();
            //IEnumerable<Users> Users = context.Users.Include(x => x.Persona).Where(x => x.Persona.Apellido == TituloGrupo).ToList();
            Log.Information("Users: {@Users}", Users);
            return Users;
        }

        /// <summary>
        /// CU-001 - Registrar Usuario
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        ///

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
            var result = await _usersServices.CreateAsync(user);

            return CreatedAtAction(nameof(Register), new { id = user.Id }, user);

        }

        //[HttpPost]
        //[Route("Token")]
        //public async Task<IActionResult> Token(LoginCredentials credentials)
        //{
        //    Log.Information("User ingresado: {@Credenciales}", credentials.email);
        //    Users identityUser;

        //    if (!ModelState.IsValid
        //        || credentials == null
        //        || (identityUser = await ValidateUser(credentials)) == null)
        //    {
        //        return new BadRequestObjectResult(
        //            new
        //            {
        //                Token = "Not Generated",
        //                Message = "Error",
        //                Email = credentials.email
        //            });
        //    }

        //    var token = GenerateToken(identityUser);
        //    Log.Information("Token granted to {@Email}", identityUser.Email);
        //    return Ok(new
        //    {
        //        Token = token,
        //        Message = "Success",
        //        Email = identityUser.Email,
        //    });
        //}

        //private async Task<Users> ValidateUser(LoginCredentials credentials)
        //{
        //    var identityUser = await userManager.FindByEmailAsync(credentials.email);

        //    if (identityUser != null)
        //    {
        //        var result = userManager.PasswordHasher.VerifyHashedPassword(identityUser, identityUser.PasswordHash, credentials.Password);
        //        return result == PasswordVerificationResult.Failed ? null : identityUser;
        //    }

        //    //TODO: Corregir devolucion
        //    return null;
        //}

        //private object GenerateToken(Users identityUser)
        //{
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(jwtBearerTokenSettings.SecretKey);

        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new Claim[]
        //        {
        //            new Claim(ClaimTypes.Name, identityUser.UserName.ToString()),
        //            new Claim(ClaimTypes.Email, identityUser.Email)
        //        }),

        //        Expires = DateTime.UtcNow.AddSeconds(jwtBearerTokenSettings.ExpiryTimeInSeconds),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
        //        Audience = jwtBearerTokenSettings.Audience,
        //        Issuer = jwtBearerTokenSettings.Issuer
        //    };

        //    var token = tokenHandler.CreateToken(tokenDescriptor);
        //    return tokenHandler.WriteToken(token);
        //}

        [HttpPost]
        [Route("FavoriteBusiness")]
        public async Task<IActionResult> AssignFavoriteBusinessToUserAsync(string userId, string businessURL)
        {
            Users? user = await _genericRepository.GetByIdAsync(userId);
            Businesses? businesses = _context.Businesses.FirstOrDefault(x => x.ContractURL == businessURL);

            if (businesses == null || user == null)
            {
                return new BadRequestObjectResult(new { Message = "Object Business null" });
            }
            if (user.FavoriteBusiness == null)
            {
                user.FavoriteBusiness = new List<Businesses>();
            }

            user.FavoriteBusiness.Add(businesses);

            await _genericRepository.SaveAsync();
            await _context.SaveChangesAsync();

            return Ok(new { Message = "User Registration Successful" });
        }

        [HttpGet]
        [Route("Mail")]
        public async Task SendMailAsync()
        {
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.UseDefaultCredentials = true;
            smtpClient.EnableSsl = true;

            IHost host = Host.CreateDefaultBuilder().Start();

            MailAddress mailAddress = new MailAddress("emilianopolicardo@gmail.com");
            MailAddressCollection mailAddresses = new MailAddressCollection();
            mailAddresses.Add(mailAddress);

            MailMessage mailMessage = new MailMessage(mailAddress, mailAddress)
            {
                Subject = "Hello World",
                Body = "",
                From = mailAddress,
                IsBodyHtml = true
            };
            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}