using System.Linq.Expressions;

namespace Repositories
{
    public interface IProductsRepository : IGenericRepository<Products>
    {
        Task<bool> CreateAsync(Products entity);

        Task<bool> EditAsync(Products entity);

        Task<Products> FindByConditionAsync(Expression<Func<Products, bool>> predicate);

        Task<List<Products>> GetAll();

        Task<Products> GetByIdAsync(Guid Id);

        List<Products> ProductByName(string name);

        Task<IEnumerable<Products>> ProductsByBusiness(Guid businessId);

        Task<List<FavoriteProducts>> GetFavoriteProductsByUserAsync(string email);
        Task<Products> GetFullProductById(Guid id);

        Task<int> SaveAsync();

        Task<IEnumerable<Products>> SugestedProductsByBusiness(string ContractURL);
    }
}