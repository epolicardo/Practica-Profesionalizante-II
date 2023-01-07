namespace Repositories
{
    public interface IOrdersRepository : IGenericRepository<Orders>
    {
        void AddOrderItem(Orders order, OrderItem item);

        Task<Orders> ChangeOrderStatusByIdAsync(Orders order, OrderStatus orderStatus);

        Task<Orders> CreateOrderAsync(string user, Guid business);

        Task<Orders> GetFullOrderById(Guid id);

        Task<List<Orders>> GetPendingOrdersByBusinessAsync(string businessId);
    }
}