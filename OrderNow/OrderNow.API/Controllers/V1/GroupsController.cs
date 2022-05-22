namespace Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class GroupsController : Controller
    {
        private readonly DataContext context;
        private readonly IGenericRepository<Groups> _genericRepository;

        public IConfigurationHelper ConfigHelper { get; }

        public GroupsController(IGenericRepository<Groups> genericRepository, DataContext _context, IConfigurationHelper configHelper)
        {
            this.context = _context;
            ConfigHelper = configHelper;
            this._genericRepository = genericRepository;

        }
        [HttpGet]
        [Route("GroupId")]
        public async Task<Groups> GetById(string Id)
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
        public async Task<IEnumerable<Groups>> GetList()
        {
            LogContext.PushProperty("Metodo", MethodBase.GetCurrentMethod());
            LogContext.PushProperty("Server", Environment.MachineName);

            IEnumerable<Groups> Data = await _genericRepository.GetAll();
            return Data;
        }


        [HttpPost]
        [Route("Group")]
        public async Task<bool> Create(Groups entity)
        {
            LogContext.PushProperty("Metodo", MethodBase.GetCurrentMethod());
            LogContext.PushProperty("Server", Environment.MachineName);
            Log.Information("Productos: {@Productos}", entity);
            await _genericRepository.CreateAsync(entity);

            return _genericRepository.SaveAsync().IsCompleted;


        }

        [HttpPut]
        [Route("Group")]
        public async Task<bool> Update(Groups entity)
        {
            if (entity == null)
            {
                return false;
            }

            await _genericRepository.EditAsync(entity);
            return _genericRepository.SaveAsync().IsCompletedSuccessfully;
        }

        [HttpDelete]
        [Route("Group")]
        public bool Delete (Groups entity)
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
