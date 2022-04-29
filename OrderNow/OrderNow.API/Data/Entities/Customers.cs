namespace OrderNow.API.Data.Entities
{
    public class Customers : People
    {
        public bool MarkedAsVIP { get; set; }
        public List<Products> FavoriteProducts { get; set; }
        public List<Products> LastOrdered { get; set; }
        public List<Businesses> FavoriteBusinesses { get; set; }
        public List<Businesses> LastVisited { get; set; }

    }
}
