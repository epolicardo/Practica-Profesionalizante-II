namespace Services
{
    public interface IOrdersServices : IGenericServices<Order>
    {
        Task<Order> GetByIdAsync(Guid id);

        Task<Order> GetFullOrderById(Guid id);

        Task<Order> CreateOrderAsync(Guid businessId, string email);

        Task<List<Order>> GetPendingOrdersByBusiness(string businessId);

        Task AddProductToOrderAsync(Guid orderId, Guid productId, int quantity);

        Task<Order> ChangeOrderStatusByIdAsync(Order order, OrderStatus orderStatus);
    }
}