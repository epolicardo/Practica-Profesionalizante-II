namespace OrderNow.BlazorServer.Services
{
    public interface IGenericApiServices<T> where T : class
    {
        Task<List<T>> GetAll(string endpointUrl);
    }
}