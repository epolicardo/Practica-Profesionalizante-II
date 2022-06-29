namespace Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]
    public class BusinessesController : ControllerBase
    {
        private readonly IBusinessesServices _businessesServices;

        public BusinessesController(IBusinessesServices businessesServices)
        {
            LogContext.PushProperty($"Method", MethodBase.GetCurrentMethod());
            LogContext.PushProperty($"Server", Environment.MachineName);
            _businessesServices = businessesServices;
        }

        [HttpGet]
        [Route("BusinessId")]
        public async Task<Businesses> GetById(string id)
        {
            return await _businessesServices.GetByIdAsync(id);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("BusinessURL")]
        public async Task<Businesses> GetByUrlAsync(string url)
        {
            return await _businessesServices.GetBusinessIfActive(url);
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<Businesses>> GetListAsync()
        {
            LogContext.PushProperty("Metodo", MethodBase.GetCurrentMethod());
            LogContext.PushProperty("Server", Environment.MachineName);

            IEnumerable<Businesses> data = await _businessesServices.GetAll();
            return data;
        }

        [HttpPost]
        [Route("Business")]
        public async Task<IActionResult> CreateAsync(Businesses business)
        {
            LogContext.PushProperty("Metodo", MethodBase.GetCurrentMethod());
            LogContext.PushProperty("Server", Environment.MachineName);
            Log.Information("Business: {@Business}", business);

            //business.Created = DateTime.Now;
            business.LastModified = DateTime.Now;

            await _businessesServices.CreateAsync(business);

            return Ok(new { Message = "Business Registration Successful" });
        }

        [HttpPut]
        [Route("BusinessId")]
        public async Task<IActionResult> UpdateAsync(Businesses business)
        {
            if (business == null)
            {
                return Ok("No business found");
            }

            await _businessesServices.EditAsync(business);
            await _businessesServices.SaveAsync();
            return Ok(new { Message = "Business Updated Successful" });
        }

        [HttpGet]
        [Route("SuggestedProducts")]
        public async Task<IEnumerable<Products>> SuggestedProducts(string url)
        {
            return _businessesServices.SugestedProductsByBusiness(url);
        }

        [HttpGet]
        [Route("ProductsByBusiness")]
        public async Task<IEnumerable<Products>> ProductsByBusiness(string url)
        {
            return _businessesServices.ProductsByBusiness(url);
        }

        [HttpGet]
        [Route("SetAsFavorite")]
        public bool SetAsFavorite(string url, Guid userId)
        {
            return _businessesServices.SetAsFavorite(url, userId);
        }

        //[HttpGet]
        //[Route("GetDashboard")]
        //public async Task<BusinessDashboard> GetDashboard(string url)
        //{
        //    return await _businessesServices.GetDashboard(url);
        //}
    }
}