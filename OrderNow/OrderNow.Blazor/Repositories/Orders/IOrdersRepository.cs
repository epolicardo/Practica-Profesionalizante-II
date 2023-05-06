namespace Repositories
{
    public interface IOrdersRepository : IGenericRepository<Order>
    {
        void AddOrderItem(Order order, OrderItem item);

        Task<Order> ChangeOrderStatusByIdAsync(Order order, OrderStatus orderStatus);

        Task<Order> CreateOrderAsync(string user, Guid business);

        Task<Order> GetFullOrderById(Guid id);

        Task<List<Order>> GetPendingOrdersByBusinessAsync(string businessId);
    }
}