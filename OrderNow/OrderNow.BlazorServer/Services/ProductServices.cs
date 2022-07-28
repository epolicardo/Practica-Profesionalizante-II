using OrderNow.Common.Data.Entities;

namespace OrderNow.BlazorServer.Services
{
    public class ProductServices : GenericServices<Products>, IProductServices
    {

        private readonly IHttpClientFactory _clientFactory;
        private readonly HttpClient? _httpClient;
        private readonly string endpointUrl = "/api/v1/Products";
        public ProductServices(IHttpClientFactory clientFactory) : base(clientFactory)
        {
        }

        public Task<Products> GetByIdAsync(string Id)
        {
            return this.GetByIdAsync(Id);
        }
    }
}
