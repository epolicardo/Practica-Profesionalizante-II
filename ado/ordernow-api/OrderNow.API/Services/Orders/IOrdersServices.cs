namespace Services
{
    public interface IOrdersServices : IGenericServices<Orders>
    {
        Task<ActionResult<Orders>> CreateOrder(Businesses businesses, Users user);

        Task<IEnumerable<Orders>> GetPendingOrdersByBusiness(string businessId);
    }
}