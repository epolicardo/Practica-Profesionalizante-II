using Data.Entities;

namespace Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CategoriesController : ControllerBase
    {

        private readonly IGenericRepository<Categories> genericRepository;
        private readonly DataContext context;
        private readonly IConfigurationHelper configHelper;

        public CategoriesController(IGenericRepository<Categories> _genericRepository, DataContext _context, IConfigurationHelper configHelper)
        {
            genericRepository = _genericRepository;
            this.context = _context;
            this.configHelper = configHelper;
        }

        [HttpGet]
        [Route("GetList")]
        public async Task<IEnumerable<Categories>> GetList()
        {
            if (configHelper.UseMockup("Categorias"))
            {
                return null;
            }
            Log.Information("Categorias: ");
            return await genericRepository.GetAll();
        }


        [HttpGet]
        [Route("GetByIdAsync")]
        public async Task<Categories> GetByIdAsync(string Id)
        {
            //if (configHelper.UseMockup("Categorias"))
            //{
            //    Categoria categoria = new Categoria()
            //    {
            //        FechaAlta = DateTime.Now,
            //        UltimaModificacion = DateTime.Now,
            //        Nombre = "MockCategroia"
            //    };
            //    return categoria;
            //}
            return await genericRepository.GetByIdAsync(Id);

        }


        [HttpPost]
        [Route("CreateAsync")]

        public async Task<bool> CreateAsync(Categories entity)
        {
            if (configHelper.UseMockup("Categorias"))
            {
                return false;
            }
            return await genericRepository.CreateAsync(entity);

        }
    }
}
