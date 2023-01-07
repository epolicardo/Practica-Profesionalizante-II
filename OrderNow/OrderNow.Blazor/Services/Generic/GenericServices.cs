using System.Linq.Expressions;

namespace Services
{
    public class GenericServices<T> : IGenericServices<T> where T : class
    {
        private readonly IGenericRepository<T> _genericRepository;

        public GenericServices(IGenericRepository<T> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public Task<bool> CreateAsync(T entity)
        {
            return _genericRepository.CreateAsync(entity);
        }

        public Task<bool> EditAsync(T entity)
        {
            return _genericRepository.EditAsync(entity);
        }

        public Task<T> FindByConditionAsync(Expression<Func<T, bool>> predicate)
        {
            return _genericRepository.FindByConditionAsync(predicate);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _genericRepository.GetAll();
        }

        public async Task<T> GetByIdAsync(Guid Id)
        {
            return await _genericRepository.GetByIdAsync(Id);
        }

        public Task<int> SaveAsync()
        {
            return _genericRepository.SaveAsync();
        }
    }
}