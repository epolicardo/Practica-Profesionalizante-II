using OrderNow.Blazor.Data;

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

        public async Task<List<UsersBusinesses>> GetBusinessesByUser(Users users)
        {
            return await _dataContext.UsersBusinesses.Where(x => x.Users.Email == users.Email).ToListAsync();
        }

        public async Task<bool> SetAsFavorite(string url, Guid userId)
        {
            var business = await _businessesRepository.FindByConditionAsync(x => x.ContractURL.Equals(url));

            if (business != null)
            {
                var user = await _usersRepository.GetByIdAsync(userId);

                if (user != null)
                {
                    FavoriteBusiness favoriteBusiness = new FavoriteBusiness();
                    favoriteBusiness.Business = business;
                    favoriteBusiness.Users = user;
                    var res = await _dataContext.FavoriteBusinessesByUser.AddAsync(favoriteBusiness);
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
    }
}