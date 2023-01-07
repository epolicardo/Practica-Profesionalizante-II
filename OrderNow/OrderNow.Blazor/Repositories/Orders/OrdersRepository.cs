﻿namespace Repositories
{
    public class OrdersRepository : GenericRepository<Orders>, IOrdersRepository
    {
        private readonly DataContext _dataContext;
        private readonly IDateTimeProvider _dateTimeProvider;

        public OrdersRepository(DataContext context, IDateTimeProvider dateTimeProvider) : base(context)
        {
            _dataContext = context;
            _dateTimeProvider = dateTimeProvider;
        }

        public void AddOrderItem(Orders order, OrderNow.Common.Data.Entities.OrderItem item)
        {
            try
            {
                _dataContext.OrderItem.Add(item);
                _dataContext.Orders.Update(order);

                _dataContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Orders> ChangeOrderStatusByIdAsync(Orders order, OrderStatus orderStatus)
        {
            var orderInDB = await _dataContext.Orders.FirstOrDefaultAsync(x => x.Id == order.Id);

            if (orderInDB != null)
            {
                if (orderInDB.OrderStatus != orderStatus)
                {
                    orderInDB.OrderStatus = orderStatus;
                }
                switch (orderInDB.OrderStatus)
                {
                    case OrderStatus.NotAssigned:
                        orderInDB.OrderStatus = OrderStatus.Waiting;
                        break;

                    case OrderStatus.Waiting:
                        orderInDB.OrderStatus = OrderStatus.Processing;
                        break;

                    case OrderStatus.Processing:
                        orderInDB.OrderStatus = OrderStatus.PartiallyDelivered;
                        orderInDB.PartialCompletionOrderDate = _dateTimeProvider.UtcNow;
                        break;

                    case OrderStatus.PartiallyDelivered:
                        orderInDB.OrderStatus = OrderStatus.Completed;
                        orderInDB.CompletionOrderDate = _dateTimeProvider.UtcNow;
                        break;

                    case OrderStatus.Completed:
                        orderInDB.OrderStatus = OrderStatus.Canceled;
                        break;
                }
                orderInDB.LastModified = _dateTimeProvider.UtcNow;
                _dataContext.Update<Orders>(orderInDB);
            }
            else
            {
                await _dataContext.Orders.AddAsync(order);
            }
            await _dataContext.SaveChangesAsync();
            return order;
        }

        public async Task<Orders> CreateOrderAsync(string user, Guid businessId)
        {
            var b = await _dataContext.Businesses.FindAsync(businessId);
            var u = await _dataContext.Users.FirstOrDefaultAsync(x => x.Email == user);

            var order = new Orders
            {
                TableNro = 4,
                Created = _dateTimeProvider.UtcNow,

                OrderStatus = OrderStatus.NotAssigned,
                OrderDate = _dateTimeProvider.UtcNow
            };
            try
            {
                order.Business = b;
                order.User = u;

                _dataContext.Orders.Add(order);
                await _dataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
            }
            return order;
        }

        public async Task<Orders> GetFullOrderById(Guid id)
        {
            return await _dataContext.Orders
                .Include(x => x.Items)
                .ThenInclude(x => x.Product)
                .SingleAsync(x => x.Id == id);
        }

        public async Task<List<Orders>> GetPendingOrdersByBusinessAsync(string businessId)
        {
            //return  _context.Orders;
            var orders = await _dataContext.Orders
             .Where(s => s.Business.Id.ToString() == businessId)
             .Where(s => s.OrderStatus != OrderStatus.Completed && s.OrderStatus != OrderStatus.Canceled && s.OrderStatus != OrderStatus.NotAssigned)
             .Include(s => s.Business)
             .Include(s => s.User).ThenInclude(u => u.person).AsNoTracking()
             .ToListAsync();
            return orders;
        }
    }
}