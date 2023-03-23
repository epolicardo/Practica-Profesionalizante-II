namespace Repositories
{
    public interface IBusinessesRepository : IGenericRepository<Businesses>
    {
        Task<bool> ExistsAsync(string contractURL);

        Task<Businesses> GetByURL(string url);

        Task<List<Businesses>> GetSuggestedBusinessesAsync();
    }
}