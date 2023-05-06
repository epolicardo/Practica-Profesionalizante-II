namespace Services
{
    public interface IUsersServices : IGenericServices<Users>
    {
        Task<bool> UpdateUser(Users user);

        Task<bool> DeleteUser(Users user);

        Task<Users> GetByIdAsync(Guid Id);

        Task<IEnumerable<Users>> GetAll();

        Task<Users> GetByMailAsync(string email);

        Task<bool> SetFavoriteBusinessesByUserAsync(UserBusiness business);

        Task<List<UserBusiness>> GetFavoriteBusinessesByUserAsync(string email);

        Task<List<UserBusiness>> UpdateDateOfVisitToBusinessesByUserAsync(string email);

        Task<List<UserBusiness>> GetLastVisitedBusinessesByUserAsync(string email);

        Task<Users> GetUserDataForLogin(string email);
    }

}