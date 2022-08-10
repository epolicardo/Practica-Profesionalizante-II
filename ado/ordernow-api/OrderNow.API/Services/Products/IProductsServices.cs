namespace Services
{
    public interface IProductsServices : IGenericServices<Products>
    {
        List<Products> ProductByName(string name);


    }
}