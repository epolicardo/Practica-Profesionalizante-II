using Microsoft.EntityFrameworkCore;

namespace Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]

    public class BusinessesController : ControllerBase
    {
        private readonly IGenericRepository<Businesses> _genericRepository;
        private readonly DataContext _context;

        public BusinessesController(IGenericRepository<Businesses> genericRepository, DataContext dataContext)
        {
            this._genericRepository = genericRepository;
            _context = dataContext;
        }

        [HttpGet]
        [Route("BusinessId")]
        public async Task<Businesses> GetById(string Id)
        {
            LogContext.PushProperty("Metodo", MethodBase.GetCurrentMethod());
            LogContext.PushProperty("Server", Environment.MachineName);
            return await _genericRepository.GetByIdAsync(Id);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("BusinessURL")]
        public async Task<IActionResult> GetByURLAsync(string URL)
        {
            LogContext.PushProperty("Metodo", MethodBase.GetCurrentMethod());
            LogContext.PushProperty("Server", Environment.MachineName);
            Businesses? businesses = await _context.Businesses.Include(x => x.Address).Include(x => x.Address.City).FirstOrDefaultAsync(x => x.ContractURL.Equals(URL));
            if (businesses == null)
            {
                return Ok(URL);
            }
            if (businesses.ValidationExpires > DateTime.Today)
            {
                return Ok(businesses);

            }
            return NoContent();
        }

        /// <summary>
        /// Obtain the list of Products
        /// </summary>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Not Authorized</response>
        /// <response code="500">Internal Server error</response>
        /// [SwaggerResponse("400", typeof(HttpError))]
        /// [SwaggerResponse("401", typeof(HttpError))]
        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<Businesses>> GetListAsync()
        {
            LogContext.PushProperty("Metodo", MethodBase.GetCurrentMethod());
            LogContext.PushProperty("Server", Environment.MachineName);

            IEnumerable<Businesses> Data = await _genericRepository.GetAll();
            return Data;
        }

        //{
        //   "name": "Pizzeria Popular Unquillo",
        //   "address": {
        //       "street": "Ruta E-53",
        //       "number": "Km 22.5"
        //   },
        //   "contractURL": "/pizzeria-popular-un",
        //   "CUIT": "203078945632",
        //   "Phone": "3516260981",
        //   "LegalName": "Pizzerias Populares S.R.L"
        //}
        [HttpPost]
        [Route("Business")]
        public async Task<IActionResult> CreateAsync(Businesses Business)
        {
            LogContext.PushProperty("Metodo", MethodBase.GetCurrentMethod());
            LogContext.PushProperty("Server", Environment.MachineName);
            Log.Information("Business: {@Business}", Business);
           
            Business.Created = DateTime.Now;
            Business.LastModified = DateTime.Now;
           
            await _genericRepository.CreateAsync(Business);

            return Ok(new { Message = "Business Registration Successful" });

        }

        [HttpPut]
        [Route("BusinessId")]
        public async Task<IActionResult> UpdateAsync(Businesses Business)
        {
            if (Business == null)
            {
                return Ok("No business found");
            }

            await _genericRepository.EditAsync(Business);
            _genericRepository.SaveAsync();
            return Ok(new { Message = "Business Updated Successful" } );
        }


    }
}
