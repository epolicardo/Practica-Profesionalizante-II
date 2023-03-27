namespace Services
{
    public class ProductsServices : GenericServices<Products>, IProductsServices
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsServices(IProductsRepository productsRepository) : base(productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public Task<bool> CreateAsync(Products entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditAsync(Products entity)
        {
            throw new NotImplementedException();
        }

        public Task<Products> FindByConditionAsync(System.Linq.Expressions.Expression<Func<Products, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Products>> GetAll()
        {
            throw new NotImplementedException();
        }



        public async Task<Products> GetByIdAsync(Guid Id)
        {
            return await _productsRepository.GetByIdAsync(Id);
        }

        public async Task<Products> GetFullProductById(Guid id) =>await _productsRepository.GetFullProductById(id);

        public double CalculateDiscounts(double precio, int cantidad, int lleva, int paga)
        {
            if (cantidad == lleva)
            {
                return precio * paga;
            }
            else
            {
                if (cantidad > lleva)
                {
                    var excedente = cantidad % lleva;
                    var porcion = (cantidad - excedente) / lleva; //6
                    return precio * (excedente + (porcion * paga));
                }
                else
                {
                    return precio * cantidad;
                }
            }
        }

        public async Task<IEnumerable<Products>> SugestedProductsByBusiness(string contractURL)
        {
            return await _productsRepository.SugestedProductsByBusiness(contractURL);
        }

        public Task<IEnumerable<Products>> ProductsByBusiness(Guid businessId)
        {
            return _productsRepository.ProductsByBusiness(businessId);
        }

        public Task<List<FavoriteProducts>> GetFavoriteProductsByUserAsync(string email)
        {
            return _productsRepository.GetFavoriteProductsByUserAsync(email);
        }
    }
}