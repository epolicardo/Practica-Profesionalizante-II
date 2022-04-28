namespace OrderNow.API.Data.Entities
{
    public class Businesses : EntityBase
    {
        public string Name { get; set; }
        public Addresses Address { get; set; }
        public Image Icon { get; set; }
        public Image Regular { get; set; }
        public string ContractURL { get; set; }
        public string PromoMessage { get; set; }
        public bool IsFrachise { get; set; } = false;
        public string CUIT { get; set; }
        public string LegalName { get; set; }
        public string Phone { get; set; }
        public People CommercialContact { get; set; }
        public List<People> Users { get; set; }
        public List<Products> ProductsList { get; set; }
        public List<PaymentMethods> PaymentMethods { get; set; }
        public List<Customers> CustomersList { get; set; }
        public List<Customers> VIPCustomersList { get; set; }
        public bool IsValidated { get; set; } = false;
        public DateTime ValidationTime { get; set; }
        public DateTime ValidationExpires { get; set; }
        public float Score { get; set; }
        public UInt64 Qualification { get; set; }


    }

    public class Image
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public ImageType Type { get; set; }
    }

    public enum ImageType
    {
        Icon,
        Regular
    }
}
