using System;

namespace ProductionCRUD.Models
{
    class Product
    {
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public string Brend { get; set; }
        public double Cost { get; set; }
        public DateTime MadeDate { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
