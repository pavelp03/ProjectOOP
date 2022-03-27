using Microsoft.AspNetCore.Mvc.Rendering;
using Shooeshop.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shooeshop.Models
{
    public class ProductsVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Това поле е задължително!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Това поле е задължително!")]

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
        public List<SelectListItem> Category { get; set; }

        [EnumDataType(typeof(PurposeShoe))]
        public PurposeShoe PurposeShoe { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Това поле е задължително!")]
        public int Size { get; set; }

        
        
    }
}
