using OrderNow.Blazor.Data;
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

        //public async Task AddRelationUserBusiness(Guid user, Guid business)
        //{
        //    user = Guid.Parse("baa393a1-807d-40d3-b5df-d3b59c983827");
        //    business = Guid.Parse("198e40dc-ca7e-4b5a-84ae-1970fec979ca");
        //    var u = await _dataContext.Users.FirstOrDefaultAsync(x => x.Id == user.ToString());
        //    var b = await _dataContext.Businesses.FirstOrDefaultAsync(x => x.Id == business);

        //    UsersBusinesses relation = new UsersBusinesses()
        //    {
        //        Business = b,
        //        Users = u,
        //    };

        //    _dataContext.UsersBusinesses.Add(relation);
        //    await _dataContext.SaveChangesAsync();
        //}

        public Task<bool> CreateAsync(Users entity)
        {
            return base.CreateAsync(entity);
        }

        public Task<bool> EditAsync(Users entity)
        {
            return base.EditAsync(entity);
        }

        public Task<Users> FindByConditionAsync(Expression<Func<Users, bool>> predicate)
        {
            return base.FindByConditionAsync(predicate);
        }

        public Task<List<Users>> GetAll()
        {
            return base.GetAll();
        }

        public Task<Users> GetByIdAsync(Guid Id)
        {
            return base.GetByIdAsync(Id);
        }

        public async Task<Users> GetByMailAsync(string email)
        {
            return await _dataContext.Users?.Include(p => p.person).ThenInclude(d => d.Address).FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<List<UsersBusinesses>> GetUserDataForLogin(string email)
        {
            return await _dataContext.UsersBusinesses.Include(x => x.Business).Where(x => x.Users.Email == email).AsNoTracking().ToListAsync();
        }
    }
}