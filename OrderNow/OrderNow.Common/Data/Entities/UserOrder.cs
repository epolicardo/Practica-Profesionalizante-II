namespace OrderNow.Common.Data.Entities
{
    public class UserOrder : EntityBase
    {
        public Order Orders { get; set; }
        public Users Users { get; set; }
    }
}