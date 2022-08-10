using OrderNow.API.Data;

namespace Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsServices _productService;

        public ProductsController(IProductsServices productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("ProductId")]
        public async Task<Products> GetById(string Id)
        {
            return await _productService.GetByIdAsync(Id);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("GetByName")]
        public List<Products> GetByName(string name)
        {
            return _productService.ProductByName(name);
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
        public async Task<IEnumerable<Products>> GetListAsync()
        {
            LogContext.PushProperty("Metodo", MethodBase.GetCurrentMethod());
            LogContext.PushProperty("Server", Environment.MachineName);

            IEnumerable<Products> Data = await _productService.GetAll();
            return Data;
        }

        [HttpPost]
        [Route("Product")]
        public async Task<bool> CreateAsync(Products entity)
        {
            LogContext.PushProperty("Metodo", MethodBase.GetCurrentMethod());
            LogContext.PushProperty("Server", Environment.MachineName);
            Log.Information("Productos: {@Productos}", entity);
            await _productService.CreateAsync(entity);

            return _productService.SaveAsync().IsCompleted;
        }

        [HttpPut]
        [Route("ProductId")]
        public async Task<bool> UpdateAsync(Products entity)
        {
            if (entity == null)
            {
                return false;
            }

            await _productService.EditAsync(entity);
            return _productService.SaveAsync().IsCompletedSuccessfully;
        }
    }
}