namespace Repositories
{
    public interface IProductsRepository : IGenericRepository<Products>
    {
       List<Products> ProductByName(string name);
    }
}