using OrderNow.Blazor.Data;

namespace Repositories
{
    public class AddressesRepository : GenericRepository<Addresses>, IAddressesRepository
    {
        private readonly DataContext _ApplicationDbContext;

        public AddressesRepository(DataContext ApplicationDbContext) : base(ApplicationDbContext)
        {
            _ApplicationDbContext = ApplicationDbContext;
        }

        public async Task<bool> CreateAsync(Addresses entity)
        {
            return await base.CreateAsync(entity);
        }

        public Task<bool> EditAsync(Addresses entity)
        {
            return base.EditAsync(entity);
        }

        public Task<Addresses> FindByConditionAsync(System.Linq.Expressions.Expression<Func<Addresses, bool>> predicate)
        {
            return base.FindByConditionAsync(predicate);
        }

        public Task<List<Addresses>> GetAll()
        {
            return base.GetAll();
        }

        public Task<Addresses> GetByIdAsync(Guid Id)
        {
            return base.GetByIdAsync(Id);
        }

        public Task<int> SaveAsync()
        {
            return base.SaveAsync();
        }
    }
}