using System.Linq.Expressions;

namespace Services
{
    public interface IGenericServices<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> GetByIdAsync(string Id);

        Task<T> FindByConditionAsync(Expression<Func<T, bool>> predicate);

        Task<bool> CreateAsync(T entity);

        Task<bool> EditAsync(T entity);

        bool Delete(T entity);

        Task<int> SaveAsync();
    }
}