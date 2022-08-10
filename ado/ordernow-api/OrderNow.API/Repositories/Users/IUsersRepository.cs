namespace Repositories
{
    public interface IUsersRepository : IGenericRepository<Users>
    {
        Users GetByMailAsync(string email);
    }
}