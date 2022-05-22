
namespace Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly IConfigurationHelper _configHelper;
        private readonly IGenericRepository<Customers> _genericRepository;

        public CustomersController(IConfigurationHelper configHelper, IGenericRepository<Customers> customerRepository)
        {
            _configHelper = configHelper;
            _genericRepository = customerRepository;
        }


        [HttpGet]
        [Route("Categories")]
        public async Task<IEnumerable<Customers>> GetListAsync()
        {
            if (_configHelper.UseMockup("Clientes"))
            {
                return null;
            }
            Log.Information("Clientes: ");
            return await _genericRepository.GetAll();
        }


        [HttpGet]
        [Route("CategoryId")]
        public async Task<Customers> GetByIdAsync(string Id)
        {
            return await _genericRepository.GetByIdAsync(Id);
        }


        [HttpPost]
        [Route("Category")]

        public async Task<bool> CreateAsync(Customers entity)
        {
            if (_configHelper.UseMockup("Clientes"))
            {
                return false;
            }
            return await _genericRepository.CreateAsync(entity);

        }

        [HttpPut]
        [Route("AddressId")]
        public async Task<bool> UpdateAsync(Customers entity)
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
        public bool Delete(Customers entity)
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

