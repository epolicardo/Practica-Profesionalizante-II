namespace Repositories
{
    public interface IBusinessesRepository : IGenericRepository<Businesses>
    {
        bool Exists(string url);
    }
}