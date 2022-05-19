namespace Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    //[Authorize]

    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Groups> _genericRepository;
   
 

        public ProductsController(IGenericRepository<Groups> genericRepository, DataContext dataContext)
        {
            this._genericRepository = genericRepository;
          
        }

        [HttpGet]
        [Route("GetById")]
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
        [Route("GetList")]
        public async Task<IEnumerable<Groups>> GetList()
        {
            LogContext.PushProperty("Metodo", MethodBase.GetCurrentMethod());
            LogContext.PushProperty("Server", Environment.MachineName);

            IEnumerable<Groups> Productos = await _genericRepository.GetAll();
            return Productos;
        }


        [HttpPost]
        [Route("CreateProduct")]
        public async Task<bool> CreateProduct(Groups producto)
        {
            LogContext.PushProperty("Metodo", MethodBase.GetCurrentMethod());
            LogContext.PushProperty("Server", Environment.MachineName);
            Log.Information("Productos: {@Productos}", producto);
            await _genericRepository.CreateAsync(producto);

            return _genericRepository.SaveAsync().IsCompleted;


        }

        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<bool> UpdateProducto(Groups producto)
        {
            if (producto == null)
            {
                return false;
            }

            await _genericRepository.EditAsync(producto);
            return _genericRepository.SaveAsync().IsCompletedSuccessfully;
        }
    }
}
