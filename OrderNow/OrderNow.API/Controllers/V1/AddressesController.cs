namespace Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AddressesController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IGenericRepository<Addresses> _genericRepository;
        private readonly IConfigurationHelper _configHelper;

        public AddressesController(IGenericRepository<Addresses> genericRepository, IConfigurationHelper configHelper)
        {
            _configHelper = configHelper;
            _genericRepository = genericRepository;

        }
        [HttpGet]
        [Route("AddressId")]
        public async Task<Addresses> GetById(string Id)
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
        public async Task<IEnumerable<Addresses>> GetList()
        {
            LogContext.PushProperty("Metodo", MethodBase.GetCurrentMethod());
            LogContext.PushProperty("Server", Environment.MachineName);

            IEnumerable<Addresses> Data = await _genericRepository.GetAll();
            return Data;
        }


        [HttpPost]
        [Route("Address")]
        public async Task<bool> Create(Addresses entity)
        {
            LogContext.PushProperty("Metodo", MethodBase.GetCurrentMethod());
            LogContext.PushProperty("Server", Environment.MachineName);
            Log.Information("Addresses: {@Addresses}", entity);
            await _genericRepository.CreateAsync(entity);

            return _genericRepository.SaveAsync().IsCompleted;


        }

        [HttpPut]
        [Route("AddressId")]
        public async Task<bool> Update(Addresses entity)
        {
            if (entity == null)
            {
                return false;
            }

            await _genericRepository.EditAsync(entity);
            return _genericRepository.SaveAsync().IsCompletedSuccessfully;
        }

        [HttpDelete]
        [Route("AddressId")]
        public bool Delete(Addresses entity)
        {
            try
            {
                _genericRepository.Delete(entity);
                return true;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "No se pudo eliminar la entidad de tipo {0}", entity.GetType);

                throw new Exception("No se pudo eliminar la entidad", ex);
            }
        }

    }
}
