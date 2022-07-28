using Microsoft.AspNetCore.Mvc.ModelBinding;
using OrderNow.API.Services.Auth;
using System.Linq.Expressions;


namespace Services
{
    public class UsersServices : GenericServices<Users>, IUsersServices
    {

        private readonly IUsersRepository _usersRepository;
        private readonly UserManager<Users> _userManager;

        public UsersServices(IUsersRepository usersRepository, UserManager<Users> userManager) : base(usersRepository)
        {
            _usersRepository = usersRepository;
            _userManager = userManager;
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

        public new async Task<ActionResult> CreateAsync(Users user)
        {
            user.UserName = user.Email;
            var result = await _userManager.CreateAsync(user, user.Password);
            user.Password = _userManager.PasswordHasher.HashPassword(user, user.Password);

            if (!result.Succeeded)
            {
                var dictionary = new ModelStateDictionary();
                foreach (IdentityError error in result.Errors)
                {
                    dictionary.AddModelError(error.Code, error.Description);
                }

                return new BadRequestObjectResult(new { Message = "User Registration Failed", Errors = dictionary });
            }

            return new OkObjectResult(new { Message = "User Registration Successful", result });

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