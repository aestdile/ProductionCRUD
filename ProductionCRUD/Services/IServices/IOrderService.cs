using System;
using System.Collections.Generic;
using ProductionCRUD.Models;

namespace ProductionCRUD.Services.IServices
{
    interface IOrderService
    {
        string CreateOrder(Guid productId);
        string DeleteOrder(Guid orderId);
        Order GetOrderByProductId(Guid orderId);
        List<Order> GetAllOrders();
    }
}
