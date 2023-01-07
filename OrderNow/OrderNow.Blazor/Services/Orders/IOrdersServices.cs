namespace Services
{
    public interface IOrdersServices : IGenericServices<Orders>
    {
        Task<Orders> GetByIdAsync(Guid id);

        Task<Orders> GetFullOrderById(Guid id);

        Task<Orders> CreateOrderAsync(Guid businessId, string email);

        Task<List<Orders>> GetPendingOrdersByBusiness(string businessId);

        Task AddProductToOrderAsync(Guid orderId, Guid productId, int quantity);

        Task<Orders> ChangeOrderStatusByIdAsync(Orders order, OrderStatus orderStatus);
    }
}