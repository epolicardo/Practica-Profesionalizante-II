namespace Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
   // [Authorize]

    public class OrdersController : ControllerBase
    {

        private readonly DataContext _dataContext;
        private readonly OrdersServices _ordersServices;
        public OrdersController(OrdersServices ordersServices, DataContext dataContext)
        {
            _ordersServices = ordersServices;
            _dataContext = dataContext;
        }

        [HttpPost]
        [Route("CreateOrder")]
        public ActionResult<Orders> CreateOrder(string URL, string email)
        {
            var b =_dataContext.Businesses.FirstOrDefault(x => x.ContractURL == URL);
            var u = _dataContext.Users.FirstOrDefault(x => x.Email == email);

            var order = _ordersServices.CreateOrder(b, u);
         
            return Ok(order);

        }
        [HttpGet]
        [Route("Orders")]
        public async Task<IEnumerable<Orders>> GetOrders()
        {
            var o = await _ordersServices.GetAll();
            return o;
               
        }
        [HttpGet]
        [Route("AddProductToOrder/Id:{orderId}")]
        public void AddProductToOrder(string orderId)
        {

        }
        [Authorize]
        [HttpPost]
        [Route("GetPendingOrders/Id:{businessId}")]
        public async Task<ActionResult<IEnumerable<Orders>>> GetPendingOrdersByBusiness(string businessId)
        {
            var orders = await _ordersServices.GetPendingOrders(businessId);
            return Ok(orders);
        }
    }
}