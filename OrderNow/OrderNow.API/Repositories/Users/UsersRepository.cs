using System.Linq.Expressions;

namespace Repositories
{
    public class UsersRepository : GenericRepository<Users>, IUsersRepository
    {
        private readonly DataContext _dataContext;

        public UsersRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public Task<bool> CreateAsync(Users entity)
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

        public   Users GetByMailAsync(string email)
        {
            return  _dataContext.Users.Include(p => p.person).ThenInclude(d => d.Address).FirstOrDefault(x => x.Email == email);
        }

        public Task<int> SaveAsync()
        {
            return base.SaveAsync();
        }
    }
}