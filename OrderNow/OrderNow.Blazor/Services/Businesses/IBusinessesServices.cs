namespace Services
{
    public interface IBusinessesServices : IGenericServices<Businesses>
    {
        Task<Businesses> GetBusinessIfActive(string url);

        Task<bool> SetAsFavorite(string url, Guid userId);

        Task<List<UsersBusinesses>> GetBusinessesByUser(Users user);
    }
}