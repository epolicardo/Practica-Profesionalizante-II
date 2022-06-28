namespace Data.Entities
{
    public class OrdersDetail : EntityBase
    {
        public Products? Product { get; set; }
        public float Quantity { get; set; }
    }
}
