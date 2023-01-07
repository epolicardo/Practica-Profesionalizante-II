using OrderNow.Blazor.Data;
using System.Linq.Expressions;

namespace Services
{
    public class AddressesServices : GenericServices<Addresses>, IAddressesServices
    {
        private readonly IAddressesRepository _addressesRepository;
        private readonly DataContext _dataContext;

        public AddressesServices(DataContext dataContext, IAddressesRepository addressesRepository) : base(addressesRepository)
        {
            _dataContext = dataContext;
            _addressesRepository = addressesRepository;
        }

        public Task<bool> EditAsync(Addresses entity)
        {
            return base.EditAsync(entity);
        }

        public Task<Addresses> FindByConditionAsync(Expression<Func<Addresses, bool>> predicate)
        {
            return base.FindByConditionAsync(predicate);
        }

        public Task<IEnumerable<Addresses>> GetAll()
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