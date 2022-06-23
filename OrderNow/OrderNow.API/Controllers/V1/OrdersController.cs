using Microsoft.EntityFrameworkCore;
using OrderNow.API.Services;

namespace Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]

    public class OrdersController : ControllerBase
    {

        private readonly IGenericRepository<Orders> _genericRepository;
        private readonly DataContext _dataContext;
        private readonly OrdersServices _ordersServices;
        public OrdersController(IGenericRepository<Orders> genericRepository, DataContext dataContext)
        {
            _genericRepository = genericRepository;
            _dataContext = dataContext;
            _ordersServices = new OrdersServices(_dataContext, _genericRepository); 
        }

        [HttpPost]
        [Route("CreateOrder")]
        public ActionResult<Orders> CreateOrder(string URL, string email)
        {
            var b = _dataContext.Businesses.FirstOrDefault(x => x.ContractURL == URL);
            var u = _dataContext.User.FirstOrDefault(x => x.Email == email);

           var order = _ordersServices.CreateOrder(b,u);
            _dataContext.Orders.Add(order.Orders);
            _dataContext.UsersOrders.Add(order);
            _dataContext.SaveChangesAsync();
            return Ok(order);

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