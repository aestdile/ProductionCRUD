using System;
using System.Collections.Generic;
using System.Linq;
using ProductionCRUD.Models;
using ProductionCRUD.Services.IServices;

namespace ProductionCRUD.Services
{
    class OrderService : IOrderService
    {
        public List<Order> Orders { get; set; } = new List<Order>();
        public List<Product> Products { get; set; } = new List<Product>();

        public string CreateOrder(Guid productId)
        {
            var product = Products.FirstOrDefault(p => p.Id == productId);
            if (product == null)
            {
                return "This product is not exist.";
            }

            Order newOrder = new Order { ProductId = productId };
            Orders.Add(newOrder);
            return $"Order is created. ID: {newOrder.Id}, Product ID: {newOrder.ProductId}, Date: {newOrder.CreatedAt}";
        }

        public string DeleteOrder(Guid orderId)
        {
            Order order = Orders.FirstOrDefault(o => o.Id == orderId);
            if (order != null)
            {
                Orders.Remove(order);
                return "Order is deleted.";
            }
            return "Order is not found.";
        }

        public Order GetOrderByProductId(Guid productId)
        {
            return Orders.FirstOrDefault(order => order.ProductId == productId);
        }


        public List<Order> GetAllOrders()
        {
            return Orders;
        }
    }
}
