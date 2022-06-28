using Data.Entities;
using System.Text.Json;

namespace OrderNow.Services
{
    public class CustomersService
    {

        private readonly HttpClient _httpClient;
        public CustomersService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Users>?> GelAllAsync()
        {
            var respuesta = _httpClient.GetStringAsync($"api/customers/");
            return JsonSerializer.Deserialize<List<Users>>(await respuesta);
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
