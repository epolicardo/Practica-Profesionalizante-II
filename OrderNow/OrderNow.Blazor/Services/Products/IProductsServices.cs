using System.Linq.Expressions;

namespace Services
{
    public interface IProductsServices : IGenericServices<Product>
    {
        double CalculateDiscounts(double precio, int cantidad, int lleva, int paga);

        Task<bool> CreateAsync(Product entity);

        Task<bool> EditAsync(Product entity);

        Task<Product> FindByConditionAsync(Expression<Func<Product, bool>> predicate);

        Task<IEnumerable<Product>> GetAll();

        Task<Product> GetByIdAsync(Guid Id);


        Task<IEnumerable<Product>> ProductsByBusiness(Guid businessId);

        Task<IEnumerable<Product>> SugestedProductsByBusiness(string contractUrl);

        Task<List<FavoriteProducts>> GetFavoriteProductsByUserAsync(string email);
        Task<Product> GetFullProductById(Guid id);

    }
}