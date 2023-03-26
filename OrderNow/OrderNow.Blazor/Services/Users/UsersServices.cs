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

        public bool AddProductToOrder(Users user, Orders order, Products product)
        {
            throw new NotImplementedException();
        }

        //public async Task GetUserProfileDataAsync(string email)
        //{
        //    await _usersRepository.GetUserProfileData(email);
        //}

        //public async Task AddRelationUserBusiness(Guid user, Guid business)
        //{
        //   await  _usersRepository.AddRelationUserBusiness(user, business);
        //}

        public async Task<bool> SetFavoriteBusinessesByUserAsync(UsersBusinesses relation)
        {
            if (relation.Users == null) { return false; }

            if (relation.Business == null) { return false; }

            return await _usersRepository.SetFavoriteBusinessesByUserAsync(relation);
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

        public async Task<List<UsersBusinesses>> GetLastVisitedBusinessesByUserAsync(string email)
        {
            return await _usersRepository.GetLastVisitedBusinessesByUserAsync(email);
        }

        public async Task<List<UsersBusinesses>> GetFavoriteBusinessesByUserAsync(string email)
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

        public Task<List<UsersBusinesses>> UpdateDateOfVisitToBusinessesByUserAsync(string email)
        {
            throw new NotImplementedException();
        }
    }
}