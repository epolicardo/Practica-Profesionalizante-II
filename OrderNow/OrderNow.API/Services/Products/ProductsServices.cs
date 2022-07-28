namespace Services
{
    public class ProductsServices : GenericServices<Products>, IProductsServices
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsServices(IProductsRepository productsRepository) : base(productsRepository)
        {
            _productsRepository = productsRepository;
        }
    }
}