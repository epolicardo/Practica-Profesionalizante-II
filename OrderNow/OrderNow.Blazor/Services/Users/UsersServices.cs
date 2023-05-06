using OrderNow.Blazor.Data;
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

        public bool AddProductToOrder(Users user, Order order, Product product)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SetFavoriteBusinessesByUserAsync(UserBusiness relation)
        {
            if (relation.Users == null) { return false; }

            if (relation.Business == null) { return false; }

            return await _usersRepository.SetFavoriteBusinessesByUserAsync(relation);
        }

        public async Task<bool> RemoveFavoriteBusiness(string url, Guid userId)
        {
            return false;
        }

        public bool AssignFavoriteProductsToUsers(Users user, Product product)
        {
            if (user == null) { return false; }

            if (product == null) { return false; }

            if (user.FavoriteProducts == null)
            {
                user.FavoriteProducts = new List<Product>();
            }
            user.FavoriteProducts.Add(product);
            return true;
        }

        public async Task<Users> GetUserDataForLogin(string email)
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
            return await _usersRepository.GetUserByEmailAsync(email);
        }

        public Task<int> SaveAsync()
        {
            return base.SaveAsync();
        }

        public async Task<List<UserBusiness>> GetLastVisitedBusinessesByUserAsync(string email)
        {
            return await _usersRepository.GetLastVisitedBusinessesByUserAsync(email);
        }

        public async Task<List<UserBusiness>> GetFavoriteBusinessesByUserAsync(string email)
        {
            return await _usersRepository.GetFavoriteBusinessesByUserAsync(email);
        }

        public Task<bool> UpdateUser(Users user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUser(Users user)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserBusiness>> UpdateDateOfVisitToBusinessesByUserAsync(string email)
        {
            throw new NotImplementedException();
        }
    }
}