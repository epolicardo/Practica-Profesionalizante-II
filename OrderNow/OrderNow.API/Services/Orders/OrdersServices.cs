using OrderNow.API.Data.Entities;

namespace Services
{
    public class OrdersServices : GenericServices<Orders>, IOrdersServices
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly DataContext _dataContext;


        public OrdersServices(IOrdersRepository ordersRepository, DataContext dataContext):base(ordersRepository)
        {
            _ordersRepository = ordersRepository;
            _dataContext = dataContext;
        }

        public UsersOrders CreateOrder(Businesses businesses, Users user)
        {
           
            _ordersRepository.CreateOrder(user,businesses);
            _dataContext.SaveChangesAsync();

            return null;

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
            return await _ordersRepository.GetByIdAsync(orderId);
        }

        public async Task<IEnumerable<Orders>> GetPendingOrders(string businessId)
        {
            return await _ordersRepository.GetPendingOrdersAsync();
        }

    }
}
