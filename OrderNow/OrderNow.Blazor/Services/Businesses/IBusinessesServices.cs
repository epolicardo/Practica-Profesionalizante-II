namespace Services
{
    public interface IBusinessesServices : IGenericServices<Business>
    {
        Task<Business> GetBusinessIfActive(string url);

        Task<List<Business>> GetSuggestedBusinessesAsync();
    }
}