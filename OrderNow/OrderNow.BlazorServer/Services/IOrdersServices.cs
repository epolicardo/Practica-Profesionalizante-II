using Data.Entities;

namespace OrderNow.BlazorServer.Services
{
    public interface IOrdersServices : IGenericServices<Orders>
    {
        Task<List<Orders>> GetOrders();
        Task<Orders> GetOrderById(string Id);

        Task<List<Orders>> GetPendingOrdersByBusiness(string businessId);
    }
}