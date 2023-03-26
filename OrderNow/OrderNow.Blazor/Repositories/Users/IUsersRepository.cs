namespace Repositories
{
    public interface IUsersRepository : IGenericRepository<Users>
    {
        Task<Users> GetUserByEmailAsync(string email);

        Task<bool> SetFavoriteBusinessesByUserAsync(UsersBusinesses relation);

        Task<List<UsersBusinesses>> GetFavoriteBusinessesByUserAsync(string email);

        Task<List<UsersBusinesses>> UpdateDateOfVisitToBusinessesByUserAsync(string email);

        Task<List<UsersBusinesses>> GetLastVisitedBusinessesByUserAsync(string email);

        Task<Users> GetUserDataForLogin(string email);

        Task GetUserProfileData(string email);
    }
}