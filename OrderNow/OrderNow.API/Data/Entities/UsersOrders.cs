﻿namespace OrderNow.API.Data.Entities
{
    public class UsersOrders : EntityBase
    {
        public Orders Orders { get; set; }
        public Users Users { get; set; }
    }
}