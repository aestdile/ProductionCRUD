using System;
using ProductionCRUD.Services;
using ProductionCRUD.Models;

namespace ProductionCRUD
{
    class Program
    {
        static void Main(string[] args)
        {
        Start:
            Console.WriteLine("What are u gonna make? ");
            Console.WriteLine("Product CRUD or Order CRUD? ");
            Console.WriteLine("Choice: 1. ProductCRUD || 2. OrderCRUD || 3. Exit Programming");
            int option = Convert.ToInt32(Console.ReadLine());

            if (option == 1)
            {
                ProductService productService = new ProductService();

                while (true)
                {
                    Console.WriteLine("1. Add Product");
                    Console.WriteLine("2. Delete Product");
                    Console.WriteLine("3. Update Product");
                    Console.WriteLine("4. Get Product By Id");
                    Console.WriteLine("5. Get All Products");
                    Console.WriteLine("6. Exit and Go to Order CRUD");
                    Console.WriteLine("Choice: ");
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine(productService.AddProduct(new Product()));
                            break;
                        case 2:
                            Console.WriteLine("Enter Product ID to delete:");
                            Guid deleteId = Guid.Parse(Console.ReadLine());
                            Console.WriteLine(productService.DeleteProduct(deleteId));
                            break;
                        case 3:
                            Console.WriteLine("Enter Product ID to update:");
                            Guid updateId = Guid.Parse(Console.ReadLine());
                            Product existingProduct = productService.GetProductById(updateId);
                            if (existingProduct != null)
                            {
                                Console.WriteLine(productService.UpdateProduct(existingProduct));
                            }
                            else
                            {
                                Console.WriteLine("Product Not Found");
                            }
                            break;
                        case 4:
                            Console.WriteLine("Enter Product ID:");
                            Guid searchId = Guid.Parse(Console.ReadLine());
                            Product foundProduct = productService.GetProductById(searchId);
                            if (foundProduct != null)
                            {
                                Console.WriteLine($"Name: {foundProduct.Name}, Brand: {foundProduct.Brend}, Cost: {foundProduct.Cost}");
                            }
                            else
                            {
                                Console.WriteLine("Product Not Found");
                            }
                            break;
                        case 5:
                            var products = productService.GetAllProducts();
                            if (products.Count > 0)
                            {
                                foreach (var product in products)
                                {
                                    Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Brand: {product.Brend}, Cost: {product.Cost}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No Products Available");
                            }
                            break;
                        case 6:
                            Console.WriteLine("Going to Order CRUD...");
                            goto OrderCRUD;
                        default:
                            Console.WriteLine("Invalid Choice");
                            break;
                    }
                }
            }

        OrderCRUD:
            OrderService orderService = new OrderService();

            while (true)
            {
                Console.WriteLine("\n1. Create Order");
                Console.WriteLine("2. Delete Order");
                Console.WriteLine("3. Get Order By Product Id");
                Console.WriteLine("4. Get All Orders");
                Console.WriteLine("5. Exit Programming");
                Console.Write("Choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Product ID: ");
                        if (Guid.TryParse(Console.ReadLine(), out Guid productId))
                        {
                            Console.WriteLine(orderService.CreateOrder(productId));
                        }
                        else
                        {
                            Console.WriteLine("Entered Incorrect ID!");
                        }
                        break;

                    case "2":
                        Console.Write("Enter Product ID to delete order: ");
                        if (Guid.TryParse(Console.ReadLine(), out Guid orderId))
                        {
                            Console.WriteLine(orderService.DeleteOrder(orderId));
                        }
                        else
                        {
                            Console.WriteLine("Entered Incorrect ID!");
                        }
                        break;

                    case "3":
                        Console.Write("Enter Product ID: ");
                        if (Guid.TryParse(Console.ReadLine(), out Guid searchId))
                        {
                            Order foundOrder = orderService.GetOrderByProductId(searchId);
                            if (foundOrder != null)
                            {
                                Console.WriteLine($"Product ID: {foundOrder.ProductId}, Date: {foundOrder.CreatedAt}");
                            }
                            else
                            {
                                Console.WriteLine("Order is not found!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Entered Incorrect ID!");
                        }
                        break;

                    case "4":
                        var orders = orderService.GetAllOrders();
                        if (orders.Count > 0)
                        {
                            Console.WriteLine("\nAll Orders:");
                            foreach (var order in orders)
                            {
                                Console.WriteLine($"Product ID: {order.ProductId}, Date: {order.CreatedAt}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No orders exist!");
                        }
                        break;

                    case "5":
                        Console.WriteLine("Exit Programming!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
        }
    }
}
