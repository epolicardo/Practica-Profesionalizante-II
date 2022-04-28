using OrderNow.Data;
using Serilog;

namespace OrderNow.API.Controllers.Generic
{
  public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DataContext _context;

        public GenericRepository(DataContext context)

        {
            _context = context;

        }


        public IEnumerable<T> GetList()
        {
            return _context.Set<T>().ToList();
        }

        public async Task<T> GetByIdAsync(string Id)
        {
            return await _context.Set<T>().FindAsync(Id);
        }
        public async Task<T> GetByNameAsync(string Name)
        {
            return await _context.Set<T>().FindAsync(Name);
        }

        public bool Delete(T entity)
        {
            _context.Set<T>().Remove(entity);

            return true;
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


        public IEnumerable<T> GetAll()
        {
            try
            {

                return _context.Set<T>().ToList();
            }
            catch (Exception ex)
            {

                Log.Error(ex, "Error al obtener listas");
                return null;
            }
        }

        public Task<bool> EditAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        async Task<IEnumerable<T>> IGenericRepository<T>.GetAll()
        {
            return await _context.Set<T>().ToListAsync();
         
        }
    }
}