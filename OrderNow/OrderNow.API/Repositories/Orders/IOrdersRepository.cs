namespace Repositories
{
    public interface IOrdersRepository : IGenericRepository<Orders>
    {

        Task<ActionResult<Orders>> CreateOrder(Users user, Businesses business);
        Task<IEnumerable<Orders>> GetPendingOrdersByBusinessAsync(string businessId);
    }
}