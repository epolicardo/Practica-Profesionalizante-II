using OrderNow.Blazor.Data;
using System.Linq.Expressions;

namespace Services
{
    public class AddressesServices : GenericServices<Address>, IAddressesServices
    {
        private readonly IAddressesRepository _addressesRepository;
        private readonly DataContext _dataContext;

        public AddressesServices(DataContext dataContext, IAddressesRepository addressesRepository) : base(addressesRepository)
        {
            _dataContext = dataContext;
            _addressesRepository = addressesRepository;
        }

        public Task<bool> EditAsync(Address entity)
        {
            return base.EditAsync(entity);
        }

        public Task<Address> FindByConditionAsync(Expression<Func<Address, bool>> predicate)
        {
            return base.FindByConditionAsync(predicate);
        }

        public Task<IEnumerable<Address>> GetAll()
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