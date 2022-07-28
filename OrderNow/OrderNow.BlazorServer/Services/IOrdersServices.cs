﻿using OrderNow.Common.Data.Entities;

namespace OrderNow.BlazorServer.Services
{
    public interface IOrdersServices : IGenericServices<Orders>
    {
        Task<List<Orders>> GetOrders();
        Task<Orders> GetOrderById(string Id);

        Task<IEnumerable<Orders>> GetPendingOrdersByBusiness(string businessId);
    }
}