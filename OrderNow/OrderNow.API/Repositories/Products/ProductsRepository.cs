using System.Linq.Expressions;

namespace Repositories
{
    public class ProductsRepository : GenericRepository<Products>, IProductsRepository
    {
        private readonly DataContext _dataContext;

        public ProductsRepository(DataContext context) : base(context)
        {
            _dataContext = context;
        }

        public async Task<bool> CreateAsync(Products entity)
        {
            return await base.CreateAsync(entity);
        }
        public bool Delete(Products entity)
        {
            return base.Delete(entity);
        }

        public Task<bool> EditAsync(Products entity)
        {
            return base.EditAsync(entity);
        }

        public Task<Products> FindByConditionAsync(Expression<Func<Products, bool>> predicate)
        {
            return base.FindByConditionAsync(predicate);
        }
        public Task<IEnumerable<Products>> GetAll()
        {
            return base.GetAll();
        }

        public Task<Products> GetByIdAsync(string Id)
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

    }
}
