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

        public async Task<List<UsersBusinesses>> GetBusinessesByUser(Users users)
        {
            return await _dataContext.UsersBusinesses.Where(x => x.Users.Email == users.Email).ToListAsync();
        }

        public Task<Users> GetByIdAsync(Guid Id)
        {
            return base.GetByIdAsync(Id);
        }

        public async Task<List<UsersBusinesses>> GetFavoriteBusinessesByUserAsync(string email)
        {
            return await _dataContext.UsersBusinesses.Where(x => x.Users.Email == email).Include(x => x.Business).Include(x => x.Users).Where(x => x.IsFavorite == true).ToListAsync();
        }

        public async Task<List<UsersBusinesses>> GetLastVisitedBusinessesByUserAsync(string email)
        {
            return await _dataContext.UsersBusinesses.Where(x => x.Users.Email == email).Include(x => x.Business).Include(x => x.Users).Where(x => x.LastVisit < DateTime.Now.AddDays(15)).ToListAsync();
        }

        public async Task<Users> GetUserByEmailAsync(string email)
        {
            return await _dataContext.Users?.Include(p => p.Person).FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<Users> GetUserDataForLogin(string email)
        {
            return await _dataContext.Users.Include(x => x.AssosiatedBusiness).FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task GetUserProfileData(string email)
        {
            await _dataContext.Users.Include(x => x.Person).Where(x => x.Email == email).AsNoTracking().ToListAsync();
        }

        public Task<List<UsersBusinesses>> SetFavoriteBusinessesByUserAsync(UsersBusinesses relation)
        {
            throw new NotImplementedException();
        }

        public Task<List<UsersBusinesses>> UpdateDateOfVisitToBusinessesByUserAsync(string email)
        {
            throw new NotImplementedException();
        }

        Task<bool> IUsersRepository.SetFavoriteBusinessesByUserAsync(UsersBusinesses relation)
        {
            throw new NotImplementedException();
        }
    }
}