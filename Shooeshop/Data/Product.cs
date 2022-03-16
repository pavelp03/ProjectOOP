using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shooeshop.Data
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Size { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public PurposeShoe Purpose { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
