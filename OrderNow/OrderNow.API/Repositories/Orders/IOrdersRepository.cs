namespace Repositories
{
    public interface IOrdersRepository : IGenericRepository<Orders>
    {

        void CreateOrder(Users user, Businesses business);
        Task<IEnumerable<Orders>> GetPendingOrdersAsync();
    }
}