using OrderNow.Blazor.Data;
using System.Security.Policy;

namespace Services
{
    public class BusinessesServices : GenericServices<Businesses>, IBusinessesServices
    {
        private readonly IBusinessesRepository _businessesRepository;
        private readonly IUsersRepository _usersRepository;

        private readonly DataContext _dataContext;

        public BusinessesServices(IBusinessesRepository businessesRepository, DataContext dataContext, IUsersRepository usersRepository) : base(businessesRepository)
        {
            _businessesRepository = businessesRepository;
            _dataContext = dataContext;
            _usersRepository = usersRepository;
        }

        public async Task<Businesses> GetBusinessIfActive(string url)
        {
            return await _businessesRepository.GetByURL(url);
        }

        public async Task<bool> SetAsFavorite(string url, Guid userId)
        {
            var business = await _businessesRepository.FindByConditionAsync(x => x.ContractURL.Equals(url));

            if (business != null)
            {
                var user = await _usersRepository.GetByIdAsync(userId);

                if (user != null)
                {
                    UsersBusinesses favoriteBusiness = new UsersBusinesses();
                    favoriteBusiness.Business = business;
                    favoriteBusiness.Users = user;
                    var res = await _dataContext.UsersBusinesses.AddAsync(favoriteBusiness);
                    await _dataContext.SaveChangesAsync();
                }
                return true;
            }
            return false;
        }

        public async Task<bool> Exists(string url)
        {
            return await _businessesRepository.ExistsAsync(url);
        }

        public async Task<List<Businesses>> GetSuggestedBusinessesAsync()
        {
            return await _businessesRepository.GetSuggestedBusinessesAsync();
        }
    }
}