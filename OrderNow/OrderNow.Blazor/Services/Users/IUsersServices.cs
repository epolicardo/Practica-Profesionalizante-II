namespace Services
{
    public interface IUsersServices : IGenericServices<Users>
    {
        //Users GetByMailAsync(string email);
        //Task<ActionResult> CreateUserAsync(Users user);
        //string HashPassword(Users user, string password);
        //PasswordVerificationResult VerifyUserPassword(Users user, string passwordHash, LoginCredentials credentials);
        //   Task AddRelationUserBusiness(Guid user, Guid business);
        Task<List<UsersBusinesses>> GetUserDataForLogin(string email);

        /// <summary>
        /// Last user's businesses visited
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<List<Businesses>> GetLastVisitedBusinessesByUser(Users user);

        /// <summary>
        /// Retrieve the favorite businesses for each user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<List<FavoriteBusiness>> GetFavoriteBusinessesByUser(string email);

        Task<bool> UpdateUser(Users user);

        Task<bool> DeleteUser(Users user);

        Task<Users> GetByIdAsync(Guid Id);

        Task<IEnumerable<Users>> GetAll();

        Task<Users> GetByMailAsync(string email);
    }
}