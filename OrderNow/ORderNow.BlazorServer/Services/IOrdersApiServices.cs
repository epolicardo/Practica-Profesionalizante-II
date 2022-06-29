using Data.Entities;

namespace OrderNow.BlazorServer.Services
{
    public interface IOrdersApiServices : IGenericApiServices<Orders>    {
        Task<List<Orders>> GetOrders();
        Task<List<Orders>> GetPendingOrdersByBusiness(string businessId);
    }
}

