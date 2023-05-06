namespace OrderNow.Common.Data.Entities
{
  

    public class OrderItem : EntityBase
    {
        public Product? Product { get; set; }
        public float Quantity { get; set; } = 0;
    }
}