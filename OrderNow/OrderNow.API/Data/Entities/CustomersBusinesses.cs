namespace Data.Entities
{
    public class CustomersBusinesses : EntityBase
    {
        public Customers IdCustomer { get; set; }
        public Businesses IdBusiness { get; set; }
    }
}
