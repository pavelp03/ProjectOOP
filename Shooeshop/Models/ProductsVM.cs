using System.ComponentModel.DataAnnotations;

namespace Shooeshop.Models
{
    public class ProductsVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Това поле е задължително!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Това поле е задължително!")]
        public decimal Price { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Това поле е задължително!")]
        public int Size { get; set; }

        public int CategoryId { get; set; }
        
    }
}
