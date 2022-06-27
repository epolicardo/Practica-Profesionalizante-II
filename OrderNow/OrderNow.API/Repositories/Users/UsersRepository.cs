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
            throw new NotImplementedException();
        }

        public Task<bool> EditAsync(Users entity)
        {
            throw new NotImplementedException();
        }

        public Task<Users> FindByConditionAsync(Expression<Func<Users, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Users>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Users> GetByIdAsync(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
