using Data.Entities;

namespace OrderNow.BlazorServer.Services
{
    public class OrdersServices : GenericServices<Orders>, IOrdersServices
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly HttpClient? _httpClient;
        private readonly string endpointUrl = "/api/v1/Orders";

        public OrdersServices(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public Task<List<Orders>> GetOrders()
        {
            return base.GetAll($"{endpointUrl}/Orders");
        }
        public Task<Orders> GetOrderById(string orderId)
        {
            return base.GetByIdAsync($"{endpointUrl}/Orders/{orderId}");
        }

        public Task<List<Orders>> GetPendingOrdersByBusiness(string businessId)
        {
            return base.GetAll($"{endpointUrl}/GetPendingOrders/{businessId}");
        }
    }
}