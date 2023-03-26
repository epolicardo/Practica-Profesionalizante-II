namespace Services
{
    public interface IUsersServices : IGenericServices<Users>
    {
        Task<bool> UpdateUser(Users user);

        Task<bool> DeleteUser(Users user);

        Task<Users> GetByIdAsync(Guid Id);

        Task<IEnumerable<Users>> GetAll();

        Task<Users> GetByMailAsync(string email);

        Task<bool> SetFavoriteBusinessesByUserAsync(UsersBusinesses business);

        Task<List<UsersBusinesses>> GetFavoriteBusinessesByUserAsync(string email);

        Task<List<UsersBusinesses>> UpdateDateOfVisitToBusinessesByUserAsync(string email);

        Task<List<UsersBusinesses>> GetLastVisitedBusinessesByUserAsync(string email);

        Task<Users> GetUserDataForLogin(string email);
    }

}