using OrderNow.Blazor.Data;

namespace Repositories
{
    public class AddressesRepository : GenericRepository<Address>, IAddressesRepository
    {
        private readonly DataContext _ApplicationDbContext;

        public AddressesRepository(DataContext ApplicationDbContext) : base(ApplicationDbContext)
        {
            _ApplicationDbContext = ApplicationDbContext;
        }

        public async Task<bool> CreateAsync(Address entity)
        {
            return await base.CreateAsync(entity);
        }

        public Task<bool> EditAsync(Address entity)
        {
            return base.EditAsync(entity);
        }

        public Task<Address> FindByConditionAsync(System.Linq.Expressions.Expression<Func<Address, bool>> predicate)
        {
            return base.FindByConditionAsync(predicate);
        }

        public Task<List<Address>> GetAll()
        {
            return base.GetAll();
        }

        public Task<Address> GetByIdAsync(Guid Id)
        {
            return base.GetByIdAsync(Id);
        }

        public Task<int> SaveAsync()
        {
            return base.SaveAsync();
        }
    }
}