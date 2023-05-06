namespace Repositories
{
    public interface IBusinessesRepository : IGenericRepository<Business>
    {
        Task<bool> ExistsAsync(string contractURL);

        Task<Business> GetByURL(string url);

        Task<List<Business>> GetSuggestedBusinessesAsync();
    }
}