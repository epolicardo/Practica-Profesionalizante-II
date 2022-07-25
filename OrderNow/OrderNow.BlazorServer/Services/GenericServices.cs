using System.Text.Json;

namespace OrderNow.BlazorServer.Services
{
    public class GenericServices<T> : IGenericServices<T> where T : class
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly HttpClient _httpClient;

        public GenericServices(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _httpClient = _clientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7269/");
        }

        public async Task<List<T>> GetAll(string endpointUrl)
        {
            var result = new List<T>();
            var url = string.Format(endpointUrl);
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();

                result = JsonSerializer.Deserialize<List<T>>(stringResponse,
                    new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            }
            else
            {
                result = Array.Empty<T>().ToList();
            }

            return result;
        }


        public async Task<T> GetByIdAsync(string endpointUrl)
        {
            var url = string.Format(endpointUrl);
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();

                var result = JsonSerializer.Deserialize<T>(stringResponse,
                    new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            return result;
            }
            return null;
        }



        //public async Task<List<T>> GetAuthorizedList(string endpointUrl)
        //{
        //    var response = await _httpClient.SendAsync(request);

        //    var result = new List<T>();
        //    var url = string.Format(endpointUrl);
        //    var request = new HttpRequestMessage(HttpMethod.Get, url);
        //    request.Headers.Add("Accept", "application/vnd.github.v3+json");
        //    _httpClient.DefaultRequestHeaders.Authorization =
        //    new AuthenticationHeaderValue("Bearer", "Your Oauth token");

        //    var response = await _httpClient.SendAsync(request);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var stringResponse = await response.Content.ReadAsStringAsync();

        //        result = JsonSerializer.Deserialize<List<T>>(stringResponse,
        //            new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
        //    }
        //    else
        //    {
        //        result = Array.Empty<T>().ToList();
        //    }

        //    return result;
        //}
    }
}