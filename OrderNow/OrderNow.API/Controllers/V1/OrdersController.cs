namespace Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly IOrdersServices _ordersServices;

        public OrdersController(IOrdersServices ordersServices, DataContext dataContext)
        {
            _ordersServices = ordersServices;
            _dataContext = dataContext;
        }

        [HttpPost]
        [Route("CreateOrder")]
        public async Task<ActionResult<Orders>> CreateOrder(string URL, string email)
        {
            var b = _dataContext.Businesses.FirstOrDefault(x => x.ContractURL == URL);
            var u = _dataContext.Users.FirstOrDefault(x => x.Email == email);

            var order = await _ordersServices.CreateOrder(b, u);

            return Ok(order);
        }

        [HttpGet]
        [Route("Orders")]
        public async Task<ActionResult<IEnumerable<Orders>>> GetOrders()
        {
            return Ok(await _ordersServices.GetAll());
        }

        [HttpGet]
        [Route("AddProductToOrder/{orderId}")]
        public void AddProductToOrder(string orderId)
        {
        }

        // [Authorize]
        [HttpGet]
        [Route("GetPendingOrders/{businessId}")]
        public async Task<ActionResult<IEnumerable<Orders>>> GetPendingOrdersByBusiness(string businessId)
        {
            var orders = await _ordersServices.GetPendingOrdersByBusiness(businessId);
            return Ok(orders);
        }

        [HttpGet]
        [Route("GetOrderById/{orderId}")]
        public async Task<ActionResult<IEnumerable<Orders>>> GetOrderById(string orderId)
        {
            var orders = await _ordersServices.GetByIdAsync(orderId);
            return Ok(orders);
        }
    }
}