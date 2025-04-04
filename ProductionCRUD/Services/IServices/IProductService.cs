using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductionCRUD.Models;

namespace ProductionCRUD.Services.IServices
{
    interface IProductService
    {
        public string AddProduct(Product product);
        public string UpdateProduct(Product product);
        public string DeleteProduct(Guid Id);
        public List<Product> GetAllProducts();
        public Product GetProductById(Guid Id); 
    }
}
