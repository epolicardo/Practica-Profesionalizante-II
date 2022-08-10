using OrderNow.API.Data;

namespace Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly DataContext dataContext;
        private readonly IGenericRepository<Sales> genericRepository;
        private readonly IConfigurationHelper configHelper;

        public SalesController(IConfigurationHelper configurationHelper, DataContext dataContext, IGenericRepository<Sales> genericRepository)
        {
            this.configHelper = configurationHelper;
            this.dataContext = dataContext;
            this.genericRepository = genericRepository;
        }

        public IConfigurationHelper ConfigurationHelper { get; }

        [HttpPost]
        [Route("CreateAsync")]
        public int CreateAsync()
        {
         
            return 0;
        }
    }
}