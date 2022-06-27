namespace Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CategoriesController : ControllerBase
    {

        private readonly IGenericRepository<Categories> _genericRepository;
        private readonly DataContext _context;
        private readonly IConfigurationHelper _configHelper;

        public CategoriesController(IGenericRepository<Categories> genericRepository, DataContext context, IConfigurationHelper configHelper)
        {
            _genericRepository = genericRepository;
            _context = context;
            _configHelper = configHelper;
        }

        [HttpGet]
        [Route("Categories")]
        public async Task<IEnumerable<Categories>> GetListAsync()
        {
            if (_configHelper.UseMockup("Categorias"))
            {
                return null;
            }
            Log.Information("Categorias: ");
            return await _genericRepository.GetAll();
        }


        [HttpGet]
        [Route("CategoryId")]
        public async Task<Categories> GetByIdAsync(string Id)
        {
            return await _genericRepository.GetByIdAsync(Id);
        }


        [HttpPost]
        [Route("Category")]

        public async Task<bool> CreateAsync(Categories entity)
        {
            if (_configHelper.UseMockup("Categorias"))
            {
                return false;
            }

            return await _genericRepository.CreateAsync(entity);

        }

        [HttpPut]
        [Route("CategoryId")]
        public async Task<bool> UpdateAsync(Categories entity)
        {
            if (entity == null)
            {
                return false;
            }

            await _genericRepository.EditAsync(entity);
            return _genericRepository.SaveAsync().IsCompletedSuccessfully;
        }

        [HttpDelete]
        [Route("CategoryId")]
        public bool Delete(Categories entity)
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
