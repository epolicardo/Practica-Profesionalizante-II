namespace Repositories
{
    public class OrdersRepository : GenericRepository<Orders>, IOrdersRepository
    {
        private readonly DataContext _dataContext;

        public OrdersRepository(DataContext DataContext) : base(DataContext)
        {
            _dataContext = DataContext;
        }

        public async Task<ActionResult<Orders>> CreateOrder(Users user, Businesses business)
        {
            var order = new Orders
            {
                TableNro = 4,
            };
            
            order.Business = business;
            order.User = user;
            order.Details = new OrdersDetail();
            await _dataContext.Orders.AddAsync(order);
            
            await _dataContext.SaveChangesAsync();
            return order;
        }

        public async Task<IEnumerable<Orders>> GetPendingOrdersByBusinessAsync(string businessId)
        {
            return await _dataContext.Orders
                .Where(s => s.Business.Id.ToString() == businessId)
                .Where(s => s.OrderStatus != OrderStatus.Completed)
                .Include(s=>s.Business)
                .Include(s=>s.User)
                .ToListAsync();
        }

    }
}
