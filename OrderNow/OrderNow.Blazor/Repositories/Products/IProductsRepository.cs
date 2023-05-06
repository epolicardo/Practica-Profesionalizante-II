using System.Linq.Expressions;

namespace Repositories
{
    public interface IProductsRepository : IGenericRepository<Product>
    {
        Task<bool> CreateAsync(Product entity);

        Task<bool> EditAsync(Product entity);

        Task<Product> FindByConditionAsync(Expression<Func<Product, bool>> predicate);

        Task<List<Product>> GetAll();

        Task<Product> GetByIdAsync(Guid Id);

        List<Product> ProductByName(string name);

        Task<IEnumerable<Product>> ProductsByBusiness(Guid businessId);

        Task<List<FavoriteProducts>> GetFavoriteProductsByUserAsync(string email);
        Task<Product> GetFullProductById(Guid id);

        Task<int> SaveAsync();

        Task<IEnumerable<Product>> SugestedProductsByBusiness(string ContractURL);
    }
}