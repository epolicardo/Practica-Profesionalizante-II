namespace Data.Entities
{
    public class CustomersBusinesses : EntityBase
    {
        public User IdUsers { get; set; }
        public Businesses IdBusiness { get; set; }
    }

    public class FavoriteProducts:EntityBase{
        public Products IdProduct { get; set; }
        public User IdUsers { get; set; }
    }


    public class FavoriteBusiness : EntityBase
    {
        public Businesses IdBusiness { get; set; }
        public User IdUsers  { get; set; }
    }


}
