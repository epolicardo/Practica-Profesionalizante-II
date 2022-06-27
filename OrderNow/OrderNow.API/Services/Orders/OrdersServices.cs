using OrderNow.API.Data.Entities;

namespace Services
{
    public class OrdersServices
    {
        private readonly IGenericRepository<Orders> _genericRepository;
        private readonly DataContext _context;

        public OrdersServices(DataContext context, IGenericRepository<Orders> genericRepository)
        {
            _context = context;
            _genericRepository = genericRepository;
        }
        public UsersOrders CreateOrder(Businesses businesses, Users user)
        {
            Orders orders = new Orders();

            UsersOrders order = new UsersOrders();

            orders.Business = businesses;
            order.Orders = orders;
            order.Users = user;

            return order;

        }
        public void AddProductToOrder(Orders orders, Products product, float quantity)
        {

        }

        public void RemoveProductFromOrder(Orders orders, Products product, float quantity)
        {

        }

        public void ModifyProductInOrder(Orders orders, Products product, float quantity)
        {

        }
        public async Task<Orders> ShowFullOrder(string orderId)
        {
            return await _genericRepository.GetByIdAsync(orderId);
        }

        public async Task<IEnumerable<Orders>> GetPendingOrders(string businessId)
        {
            return await _context.Orders.Where(s => s.OrderStatus != OrderStatus.Completed).ToListAsync();
        }

    }
}
