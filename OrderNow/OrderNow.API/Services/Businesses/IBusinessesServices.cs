namespace Services
{
    public interface IBusinessesServices : IGenericServices<Businesses>
    {

        Task<Businesses> GetBusinessIfActive(string url);
        IEnumerable<Products> SugestedProductsByBusiness(string url);
        IEnumerable<Products> ProductsByBusiness(string url);
        bool SetAsFavorite(string url, Guid userId);
    }
}
