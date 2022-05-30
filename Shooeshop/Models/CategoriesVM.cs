using Microsoft.AspNetCore.Mvc.Rendering;
using Shooeshop.Data;
using System.Collections.Generic;

namespace Shooeshop.Models
{
    public class CategoriesVM
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<SelectListItem> Products { get; set; }
    }
}
