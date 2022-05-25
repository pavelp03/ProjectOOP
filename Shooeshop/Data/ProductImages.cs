using System;
using System.ComponentModel.DataAnnotations;

namespace Shooeshop.Data
{
    public class ProductImages
    {
        
            public ProductImages()
            {
                this.Id = Guid.NewGuid().ToString();
            }
            [Key]
            public string Id { get; set; }
            [Required]
            public string ImagePath { get; set; }

            //wrazka M:1
            [Required]
            //[ForeignKey("Product")]
            public int ProductId { get; set; }

            public Product Product { get; set; }

        }
    }

