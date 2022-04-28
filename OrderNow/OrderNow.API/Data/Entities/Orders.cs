namespace OrderNow.API.Data.Entities
{
    public class Orders : EntityBase
    {
        public Businesses Business { get; set; }
        public Customers Customer { get; set; }
        public List<Products> ProductsList { get; set; }
        public Users User { get; set; }
        public decimal TotalAmount { get; set; }
        public PaymentMethods PaymentMethod { get; set; }

    }
}
