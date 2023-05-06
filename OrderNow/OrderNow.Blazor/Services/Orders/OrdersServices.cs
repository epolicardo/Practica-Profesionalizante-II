namespace Services
{
    public class OrdersServices : GenericServices<Order>, IOrdersServices
    {
        private readonly IBusinessesRepository _businessRepository;
        private readonly IOrdersRepository _ordersRepository;
        private readonly IProductsRepository _productsRepository;
        private readonly IUsersRepository _usersRepository;

        public OrdersServices(IOrdersRepository ordersRepository, IUsersRepository usersRepository, IBusinessesRepository businessRepository, IProductsRepository productsRepository) : base(ordersRepository)
        {
            _ordersRepository = ordersRepository;
            _usersRepository = usersRepository;
            _businessRepository = businessRepository;

            _productsRepository = productsRepository;
        }

        public async Task AddProductToOrderAsync(Guid orderId, Guid productId, int quantity)
        {
            var order = await _ordersRepository.GetFullOrderById(orderId);
            var products = await _productsRepository.GetByIdAsync(productId);
            OrderItem item = new OrderItem();
            item.Quantity = quantity;
            item.Product = products;

            if (!order.Items.Any())
            {
                order.Items.Add(item);
            }
            else
            {
                foreach (var prod in order.Items)
                {
                    if (prod.Product.Id == productId)
                    {
                        prod.Quantity = prod.Quantity + quantity;
                        break;
                    }
                    else
                    {
                        order.Items.Add(item);
                    }
                }
            }

            _ordersRepository.AddOrderItem(order, item);
        }

        public async Task<Order> ChangeOrderStatusByIdAsync(Order order, OrderStatus orderStatus)
        {
            return await _ordersRepository.ChangeOrderStatusByIdAsync(order, orderStatus);
        }

        public async Task<Order> CreateOrderAsync(Guid businessId, string email)
        {
            return await _ordersRepository.CreateOrderAsync(email, businessId);
        }

        public async Task<Order> GetFullOrderById(Guid id)
        {
            return await _ordersRepository.GetFullOrderById(id);
        }

        public async Task<List<Order>> GetPendingOrdersByBusiness(string businessId)
        {
            return await _ordersRepository.GetPendingOrdersByBusinessAsync(businessId);
        }

        public void ModifyProductInOrder(Order orders, Product product, float quantity)
        {
        }

        public void RemoveProductFromOrder(Order orders, Product product, float quantity)
        {
        }
    }
}