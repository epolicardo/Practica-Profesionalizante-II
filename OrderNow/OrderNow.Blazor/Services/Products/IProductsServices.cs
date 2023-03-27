using System.Linq.Expressions;

namespace Services
{
    public interface IProductsServices : IGenericServices<Products>
    {
        double CalculateDiscounts(double precio, int cantidad, int lleva, int paga);

        Task<bool> CreateAsync(Products entity);

        Task<bool> EditAsync(Products entity);

        Task<Products> FindByConditionAsync(Expression<Func<Products, bool>> predicate);

        Task<IEnumerable<Products>> GetAll();

        Task<Products> GetByIdAsync(Guid Id);


        Task<IEnumerable<Products>> ProductsByBusiness(Guid businessId);

        Task<IEnumerable<Products>> SugestedProductsByBusiness(string contractUrl);

        Task<List<FavoriteProducts>> GetFavoriteProductsByUserAsync(string email);
        Task<Products> GetFullProductById(Guid id);

    }
}