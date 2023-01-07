namespace OrderNow.Common.Data.Entities
{
  

    public class OrderItem : EntityBase
    {
        public Products? Product { get; set; }
        public float Quantity { get; set; } = 0;
    }
}