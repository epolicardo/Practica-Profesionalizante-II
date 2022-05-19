namespace Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    //[Authorize]

    public class BusinessesController : ControllerBase
    {
        private readonly IGenericRepository<Businesses> _genericRepository;



        public BusinessesController(IGenericRepository<Businesses> genericRepository, DataContext dataContext)
        {
            this._genericRepository = genericRepository;

        }

        [HttpGet]
        [Route("GetById")]
        public async Task<Businesses> GetById(string Id)
        {
            LogContext.PushProperty("Metodo", MethodBase.GetCurrentMethod());
            LogContext.PushProperty("Server", Environment.MachineName);
            return await _genericRepository.GetByIdAsync(Id);
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
        [Route("GetList")]
        public async Task<IEnumerable<Businesses>> GetList()
        {
            LogContext.PushProperty("Metodo", MethodBase.GetCurrentMethod());
            LogContext.PushProperty("Server", Environment.MachineName);

            IEnumerable<Businesses> Business = await _genericRepository.GetAll();
            return Business;
        }


        [HttpPost]
        [Route("CreateProduct")]
        public async Task<bool> CreateProduct(Businesses Business)
        {
            LogContext.PushProperty("Metodo", MethodBase.GetCurrentMethod());
            LogContext.PushProperty("Server", Environment.MachineName);
            Log.Information("Productos: {@Productos}", Business);
            await _genericRepository.CreateAsync(Business);

            return _genericRepository.SaveAsync().IsCompleted;


        }

        [HttpPut]
        [Route("UpdateBusiness")]
        public async Task<bool> UpdateBusiness(Businesses Business)
        {
            if (Business == null)
            {
                return false;
            }

            await _genericRepository.EditAsync(Business);
            return _genericRepository.SaveAsync().IsCompletedSuccessfully;
        }
    }
}
