using System.Linq.Expressions;

namespace Repositories
{


    //Controlador
    //Servicipo
    //Repositorio



    public class BusinessesRepository : GenericRepository<Businesses>, IBusinessesRepository
    {
        private readonly DataContext _dataContext;

        public BusinessesRepository(DataContext context) : base(context)
        {
            _dataContext = context;
        }

        public async Task<bool> CreateAsync(Businesses entity)
        {
            try
            {
                await base.CreateAsync(entity);
                await base.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error al crear entidad");
                throw;
            }
        }

        public bool Delete(Businesses entity)
        {
            return base.Delete(entity);

        }

        public Task<bool> EditAsync(Businesses entity)
        {
            return base.EditAsync(entity);
        }

        public bool Exists(string url)
        {
            return _dataContext.Businesses.FirstOrDefault(x => x.ContractURL == url) != null ? true : false;
        }

        public Task<Businesses> FindByConditionAsync(Expression<Func<Businesses, bool>> predicate)
        {
            return base.FindByConditionAsync(predicate);
        }


        public async Task<Businesses> GetByUrl(string url)
        {
            return await base.FindByConditionAsync(x => x.ContractURL == url);
        }

        public Task<IEnumerable<Businesses>> GetAll()
        {
            return base.GetAll();
        }

        public Task<Businesses> GetByIdAsync(string Id)
        {
            return base.GetByIdAsync(Id);
        }

        public Task<int> SaveAsync()
        {
            return base.SaveAsync();
        }


        public IEnumerable<Products> SugestedProductsByBusiness(string url)
        {

            return null;
        }

        public IEnumerable<Products> ProductsByBusiness(string URL)
        {

            var products = _dataContext.Products.Where(x => x.Business.ContractURL == URL).ToList();

            return products;

        }


        public List<Products> ProductsByBusinessByCategory(string URL, Categories Category)
        {

            var products = _dataContext.Products.Where(x => x.Business.ContractURL == URL).Where(p => p.Category.Name == Category.Name).ToList();

            return products;

        }


        public void ValidateBusiness() { }



        //public async Task<ActionResult<Businesses>> BusinessPortal(string URL)
        //{
        //    Businesses? business = await _dataContext.FindByConditionAsync(x => x.ContractURL == URL);

        //    if (business.IsValidated && business.ValidationExpires > DateTime.Today)
        //    {
        //        return business;

        //    }
        //    return null;

        //}

        //[HttpGet]
        //[Route("GetCustomerByName/{customerName}")]
        //public async Task<ActionResult<Customer>> GetCustomerByName(string customerName)
        //{
        //    return Ok(await _customerRepository.FindByConditionAsync(a => a.Name == customerName));
        //}
    }
}

