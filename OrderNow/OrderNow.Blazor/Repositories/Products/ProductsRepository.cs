using System.Linq.Expressions;

namespace Repositories
{
    public class ProductsRepository : GenericRepository<Products>, IProductsRepository
    {
        private readonly DataContext _context;

        public ProductsRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(Products entity)
        {
            throw new NotImplementedException();
            //return await base.CreateAsync(entity);
        }

        public Task<bool> EditAsync(Products entity)
        {
            throw new NotImplementedException();

            //return base.EditAsync(entity);
        }

        public Task<Products> FindByConditionAsync(Expression<Func<Products, bool>> predicate)
        {
            throw new NotImplementedException();

            //return base.FindByConditionAsync(predicate);
        }

        public async Task<List<Products>> GetAll()
        {
            return await base.GetAll();
        }

        public async Task<Products> GetByIdAsync(Guid Id)
        {
            var a = await _context.Products.FirstOrDefaultAsync(x => x.Id == Id);
            return a;
        }

        public List<Products> ProductByName(string name)
        {
            var products = _context.Products
                .Include(x => x.Recipe)
                .ThenInclude(x => x.Ingredients)
                .ThenInclude(x => x.Ingredient)
                .Where(x => x.Name == name).ToList();

            foreach (var item in products)
            {
                foreach (var ing in item.Recipe.Ingredients)
                {
                    if (ing.Ingredient.Stock < ing.Quantity)
                    {
                        Console.WriteLine("No hay suficiente stock para preparar este producto");
                    }
                }
            }

            return products;
        }

        public async Task<IEnumerable<Products>> ProductsByBusiness(Guid businessId)
        {
            return await _context.Products.Where(x => x.Business.Id == businessId).ToListAsync();
        }

        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
            //return _context.Products.SaveAsync();
        }

        public async Task<IEnumerable<Products>> SugestedProductsByBusiness(Guid businessId)
        {
            return await _context.Products.Include(x => x.Category).Where(x => x.Business.Id == businessId).Where(p => p.IsSuggested == true).ToListAsync();
        }

        public List<Products> ProductsByBusinessByCategory(string URL, Categories Category)
        {
            var products = _context.Products.Where(x => x.Business.ContractURL == URL).Where(p => p.Category.Name == Category.Name).ToList();

            return products;
        }
    }
}