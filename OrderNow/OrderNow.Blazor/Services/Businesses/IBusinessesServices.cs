namespace Services
{
    public interface IBusinessesServices : IGenericServices<Businesses>
    {
        Task<Businesses> GetBusinessIfActive(string url);

        Task<List<Businesses>> GetSuggestedBusinessesAsync();
    }
}