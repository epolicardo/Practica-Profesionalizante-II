using System.Linq.Expressions;

namespace Services
{
    public class UsersServices : GenericServices<Users>, IUsersServices
    {
        private readonly IUsersRepository _usersRepository;

        public UsersServices(IUsersRepository usersRepository, UserManager<Users> userManager) : base(usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public bool AddProductToOrder(Users user, Orders order, Products product)
        {
            throw new NotImplementedException();
        }

        //public async Task AddRelationUserBusiness(Guid user, Guid business)
        //{
        //   await  _usersRepository.AddRelationUserBusiness(user, business);
        //}

        public bool AssignFavoriteBusinessToUser(Users user, Businesses business)
        {
            if (user == null) { return false; }

            if (business == null) { return false; }

            if (user.FavoriteBusiness == null)
            {
                user.FavoriteBusiness = new List<Businesses>();
            }
            user.FavoriteBusiness.Add(business);
            return true;
        }

        public bool AssignFavoriteProductsToUsers(Users user, Products product)
        {
            if (user == null) { return false; }

            if (product == null) { return false; }

            if (user.FavoriteProducts == null)
            {
                user.FavoriteProducts = new List<Products>();
            }
            user.FavoriteProducts.Add(product);
            return true;
        }

        public async Task<List<UsersBusinesses>> GetUserDataForLogin(string email)
        {
            return await _usersRepository.GetUserDataForLogin(email);
        }

        public Task<bool> EditAsync(Users entity)
        {
            return base.EditAsync(entity);
        }

        public Task<Users> FindByConditionAsync(Expression<Func<Users, bool>> predicate)
        {
            return base.FindByConditionAsync(predicate);
        }

        public Task<IEnumerable<Users>> GetAll()
        {
            return base.GetAll();
        }

        public Task<Users> GetByIdAsync(Guid Id)
        {
            return base.GetByIdAsync(Id);
        }

        public async Task<Users> GetByMailAsync(string email)
        {
            return await _usersRepository.GetByMailAsync(email);
        }

        public Task<int> SaveAsync()
        {
            return base.SaveAsync();
        }
    }
}