namespace OrderNow.BlazorServer.Services
{
    public interface IGenericServices<T> where T : class
    {
        Task<List<T>> GetAll(string endpointUrl);
        Task<T> GetByIdAsync(string url);
    }
}