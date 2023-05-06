namespace Repositories
{
    public interface IUsersRepository : IGenericRepository<Users>
    {
        Task<Users> GetUserByEmailAsync(string email);

        Task<bool> SetFavoriteBusinessesByUserAsync(UserBusiness relation);

        Task<List<UserBusiness>> GetFavoriteBusinessesByUserAsync(string email);

        Task<List<UserBusiness>> UpdateDateOfVisitToBusinessesByUserAsync(string email);

        Task<List<UserBusiness>> GetLastVisitedBusinessesByUserAsync(string email);

        Task<Users> GetUserDataForLogin(string email);

        Task GetUserProfileData(string email);
    }
}