using OrderNow.Blazor.Data;
using System.Linq.Expressions;

namespace Repositories
{
    public class BusinessesRepository : GenericRepository<Businesses>, IBusinessesRepository
    {
        private readonly DataContext _context;

        public BusinessesRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Businesses>> GetSuggestedBusinessesAsync()
        {
            return await _context.Businesses.Where(x => x.IsPromoted == true && x.PromotionCredits > 0).ToListAsync();
        }

        public async Task<bool> CreateAsync(Businesses entity)
        {
            return await base.CreateAsync(entity);
        }

        public Task<bool> EditAsync(Businesses entity)
        {
            return base.EditAsync(entity);
        }

        public async Task<bool> ExistsAsync(string url)
        {
            return await _context.Businesses.FirstOrDefaultAsync(x => x.ContractURL == url) != null ? true : false;
        }

        public Task<Businesses> FindByConditionAsync(Expression<Func<Businesses, bool>> predicate)
        {
            return base.FindByConditionAsync(predicate);
        }

        public Task<List<Businesses>> GetAll()
        {
            return base.GetAll();
        }

        public Task<Businesses> GetByIdAsync(Guid Id)
        {
            return base.GetByIdAsync(Id);
        }

        public async Task<Businesses> GetByURL(string url)

        {
            return _context.Businesses.Include(x => x.Address).FirstOrDefaultAsync(x => x.ContractURL == url).GetAwaiter().GetResult();
        }

        public Task<int> SaveAsync()
        {
            return base.SaveAsync();
        }

        public void ValidateBusiness()
        { }

        //[HttpGet]
        //[Route("GetCustomerByName/{customerName}")]
        //public async Task<ActionResult<Customer>> GetCustomerByName(string customerName)
        //{
        //    return Ok(await _customerRepository.FindByConditionAsync(a => a.Name == customerName));
        //}
    }
}