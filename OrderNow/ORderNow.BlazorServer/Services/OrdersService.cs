using Data.Entities;
using System.Text.Json;

namespace OrderNow.Services
{
    public class OrdersService
    {

        private readonly HttpClient _httpClient;
        public OrdersService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Orders>?> GelAllAsync()
        {
            var respuesta = _httpClient.GetStringAsync($"api/orders/");
            return JsonSerializer.Deserialize<List<Orders>>(await respuesta);
        }

        //public async Task<ClienteModel> GetUnCliente(int id)
        //{
        //    return await _httpClient.GetFromJsonAsync<ClienteModel>($"api/clientes/{id}");
        //}

        //public async Task<bool> ExisteCliente(long dni)
        //{
        //    var respuesta = _httpClient.GetStringAsync($"api/clientes/existe/{dni}");
        //    return JsonConvert.DeserializeObject<bool>(await respuesta);
        //}
    }
}
