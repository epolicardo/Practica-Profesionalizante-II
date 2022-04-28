namespace OrderNow.API.Data.Entities
{
    public class Customers : People
    {
        public List<Products> FavoriteProducts { get; set; }
        public List<Businesses> FavoriteBusinesses { get; set; }
    }
}
