namespace Services
{
    public interface IUsersServices : IGenericServices<Users>
    {

        Users GetByMailAsync(string email);

    }
}