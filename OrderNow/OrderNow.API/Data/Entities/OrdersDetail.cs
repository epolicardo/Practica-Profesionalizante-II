namespace Data.Entities
{
    public class OrdersDetail : EntityBase
    {
        public float Quantity { get; set; }
        public Products Product { get; set; }
    }
}
