namespace Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    //[Authorize]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AddressesController : ControllerBase
    {
        private readonly IGenericRepository<Addresses> _genericRepository;
        private readonly IConfigurationHelper _configHelper;

        public AddressesController(IGenericRepository<Addresses> genericRepository, IConfigurationHelper configHelper)
        {
            _configHelper = configHelper;
            _genericRepository = genericRepository;
        }

        [HttpGet]
        [Route("AddressId")]
        public async Task<Addresses> GetByIdAsync(Guid Id)
        {
            LogContext.PushProperty("Metodo", MethodBase.GetCurrentMethod());
            LogContext.PushProperty("Server", Environment.MachineName);
            return await _genericRepository.GetByIdAsync(Id.ToString());
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<Addresses>> GetListAsync()
        {
            LogContext.PushProperty("Metodo", MethodBase.GetCurrentMethod());
            LogContext.PushProperty("Server", Environment.MachineName);

            IEnumerable<Addresses> Data = await _genericRepository.GetAll();
            return Data;
        }

        [HttpPost]
        [Route("Address")]
        public async Task<bool> CreateAsync(Addresses entity)
        {
            LogContext.PushProperty("Metodo", MethodBase.GetCurrentMethod());
            LogContext.PushProperty("Server", Environment.MachineName);
            Log.Information("Addresses: {@Addresses}", entity);
            await _genericRepository.CreateAsync(entity);

            return _genericRepository.SaveAsync().IsCompleted;
        }

        [HttpPut]
        [Route("AddressId")]
        public async Task<bool> UpdateAsync(Addresses entity)
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