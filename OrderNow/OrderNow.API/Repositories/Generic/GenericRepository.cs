using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;
namespace Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DataContext _context;

        public GenericRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(string Id)
        {
            return await _context.Set<T>().FindAsync(Id);
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();

        }

        public async Task<T> FindByConditionAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public async Task<bool> CreateAsync(T entity)
        {
            try
            {
                _context.Set<T>().Add(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error al crear entidad");
                throw;
            }
        }
        public async Task<bool> EditAsync(T entity)
        {
            EntityEntry<T> entityEntry = _context.Set<T>().Update(entity);
            return entityEntry.State == EntityState.Modified;
        }
        //TODO Chequear el tipo de dato retornado.
        public bool Delete(T entity)
        {
            return _context.Set<T>().Remove(entity).State.HasFlag(EntityState.Deleted);

        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }






        //public async Task<T> GetByNameAsync(string Name)
        //{
        //    return await _context.Set<T>().FindAsync(Name);
        //}
    }
}