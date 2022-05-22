namespace Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]

    public class BusinessesController : ControllerBase
    {
        private readonly IGenericRepository<Businesses> _genericRepository;

        public BusinessesController(IGenericRepository<Businesses> genericRepository, DataContext dataContext)
        {
            this._genericRepository = genericRepository;

        }

        [HttpGet]
        [Route("BusinessId")]
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
        [Route("")]
        public async Task<IEnumerable<Businesses>> GetListAsync()
        {
            LogContext.PushProperty("Metodo", MethodBase.GetCurrentMethod());
            LogContext.PushProperty("Server", Environment.MachineName);

            IEnumerable<Businesses> Data = await _genericRepository.GetAll();
            return Data;
        }


        [HttpPost]
        [Route("Business")]
        public async Task<bool> CreateAsync(Businesses Business)
        {
            LogContext.PushProperty("Metodo", MethodBase.GetCurrentMethod());
            LogContext.PushProperty("Server", Environment.MachineName);
            Log.Information("Productos: {@Productos}", Business);
            await _genericRepository.CreateAsync(Business);

            return _genericRepository.SaveAsync().IsCompleted;


        }

        [HttpPut]
        [Route("BusinessId")]
        public async Task<bool> UpdateAsync(Businesses Business)
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
