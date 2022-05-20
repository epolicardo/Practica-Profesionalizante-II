namespace Data.Entities
{
    public class CustomersBusinesses : EntityBase
    {
        public Customers IdCustomer { get; set; }
        public Businesses IdBusiness { get; set; }
    }

    public class FavoriteProducts:EntityBase{
        public Products IdProduct { get; set; }
        public Customers IdCustomer { get; set; }
    }


    public class FavoriteBusiness : EntityBase
    {
        public Businesses IdBusiness { get; set; }
        public Customers IdCustomer { get; set; }
    }


}
