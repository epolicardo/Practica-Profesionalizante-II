namespace Services
{
    public class ProductsServices : GenericServices<Products>, IProductsServices
    {
        public ProductsServices(IGenericRepository<Products> genericRepository) : base(genericRepository)
        {
        }
    }
}
