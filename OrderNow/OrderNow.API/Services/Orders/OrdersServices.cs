namespace Services
{
    public class OrdersServices : GenericServices<Orders>, IOrdersServices
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly DataContext _dataContext;

        public OrdersServices(IOrdersRepository ordersRepository, DataContext dataContext) : base(ordersRepository)
        {
            _ordersRepository = ordersRepository;
            _dataContext = dataContext;
        }

        public async Task<ActionResult<Orders>> CreateOrder(Businesses businesses, Users user)
        {
            return await _ordersRepository.CreateOrder(user, businesses);
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

        public async Task<IEnumerable<Orders>> GetPendingOrdersByBusiness(string businessId)
        {
            return await _ordersRepository.GetPendingOrdersByBusinessAsync(businessId);
        }
    }
}