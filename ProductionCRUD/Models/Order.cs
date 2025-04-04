using System;

namespace ProductionCRUD.Models
{
    class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ProductId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}



