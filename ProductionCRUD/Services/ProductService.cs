using System;
using System.Collections.Generic;
using ProductionCRUD.Models;
using ProductionCRUD.Services.IServices;

namespace ProductionCRUD.Services
{
    class ProductService : IProductService
    {
        public List<Product> Mahsulotlar { get; set; } = new List<Product>();
        public string AddProduct(Product product)
        {
            Console.Write("Enter Name: ");
            product.Name = Console.ReadLine();
            Console.Write("Enter Brend: ");
            product.Brend = Console.ReadLine();
            Console.Write("Enter Cost: ");
            product.Cost = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter Made Date: ");
            product.MadeDate = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Enter Expiration Date: ");
            product.ExpirationDate = Convert.ToDateTime(Console.ReadLine());
            Mahsulotlar.Add(product);
            return "Product Added Successfully";
        }

        public string DeleteProduct(Guid Id)
        {
            Product product = Mahsulotlar.Find(x => x.Id == Id);
            if (product != null)
            {
                Mahsulotlar.Remove(product);
                return "Product Deleted Successfully";
            }
            return "Product Not Found";
        }

        public List<Product> GetAllProducts()
        {
            return Mahsulotlar;
        }

        public Product GetProductById(Guid Id)
        {
            Product product = Mahsulotlar.Find(x => x.Id == Id);
            if (product != null)
            {
                return product;
            }
            else
            {
                return null;
            }
        }

        public string UpdateProduct(Product product)
        {
            Product product1 = Mahsulotlar.Find(x => x.Id == product.Id);
            if (product1 != null)
            {
                Console.Write("Enter Name: ");
                product1.Name = Console.ReadLine();
                Console.Write("Enter Brend: ");
                product1.Brend = Console.ReadLine();
                Console.Write("Enter Cost: ");
                product1.Cost = Convert.ToDouble(Console.ReadLine());
                Console.Write("Enter Made Date: ");
                product1.MadeDate = Convert.ToDateTime(Console.ReadLine());
                Console.Write("Enter Expiration Date: ");
                product1.ExpirationDate = Convert.ToDateTime(Console.ReadLine());
                return "Product Updated Successfully";
            }
            return "Product Not Found";
        }
    }
}
