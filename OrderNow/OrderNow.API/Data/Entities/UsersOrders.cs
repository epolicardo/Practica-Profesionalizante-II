namespace OrderNow.API.Data.Entities
{
    public class UsersOrders : EntityBase
    {
       
            public Orders Orders { get; set; }
            public User Users { get; set; }
        
    }
}
