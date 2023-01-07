namespace Repositories
{
    public interface IUsersRepository : IGenericRepository<Users>
    {
        Task<Users> GetByMailAsync(string email);

        // Task AddRelationUserBusiness(Guid user, Guid business);

        Task<List<UsersBusinesses>> GetUserDataForLogin(string email);
    }
}