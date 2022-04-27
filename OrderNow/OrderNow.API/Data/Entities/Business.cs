namespace OrderNow.API.Data.Entities
{
    public class Business : EntityBase
    {    
        public string Name { get; set; }
        public Addresses Address { get; set; }
        public string ImageURL { get; set; }
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


    }
}
