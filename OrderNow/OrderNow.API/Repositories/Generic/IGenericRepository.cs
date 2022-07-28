using System.Linq.Expressions;

namespace Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> GetByIdAsync(string Id);

        Task<T> FindByConditionAsync(Expression<Func<T, bool>> predicate);

        Task<bool> CreateAsync(T entity);

        Task<bool> EditAsync(T entity);

        Task<int> SaveAsync();
    }
}