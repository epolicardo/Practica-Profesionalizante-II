using System.Linq.Expressions;

namespace Services
{
    public interface IGenericServices<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> GetByIdAsync(Guid Id);

        Task<T> FindByConditionAsync(Expression<Func<T, bool>> predicate);

        Task<bool> CreateAsync(T entity);

        Task<bool> EditAsync(T entity);

        Task<int> SaveAsync();
    }
}