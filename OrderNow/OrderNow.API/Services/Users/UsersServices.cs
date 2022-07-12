using System.Linq.Expressions;

namespace Services
{
    public class UsersServices : GenericServices<Users>, IUsersServices
    {
        private readonly IUsersRepository _usersRepository;

        public UsersServices(IUsersRepository usersRepository) : base(usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public bool AddProductToOrder(Users user, Orders order, Products product)
        {
            throw new NotImplementedException();
        }

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

        public new Task<bool> CreateAsync(Users entity)
        {
            return base.CreateAsync(entity);
        }

        public bool Delete(Users entity)
        {
            return base.Delete(entity);
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

        public Task<Users> GetByIdAsync(string Id)
        {
            return base.GetByIdAsync(Id);
        }

        public Users GetByMailAsync(string email)
        {
            return _usersRepository.GetByMailAsync(email);
        }

        public Task<int> SaveAsync()
        {
            return base.SaveAsync();
        }
    }
}