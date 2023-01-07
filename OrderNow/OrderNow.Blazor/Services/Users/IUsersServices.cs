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
    }
}