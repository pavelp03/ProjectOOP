using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel;
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

        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }
       
        public PurposeShoeType Purpose { get; set; }
        public ICollection<ProductImages> ProductImages { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
