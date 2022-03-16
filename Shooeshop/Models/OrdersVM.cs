using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shooeshop.Models
{
    public class OrdersVM
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        public List<SelectListItem> Products { get; set; }

        public int UserId { get; set; }

        [Required(ErrorMessage = "Това поле е задължително!")]
        [DataType(DataType.Date)]
        [Display(Name = "Дата на закупуване:")]
        public DateTime OrderedOn { get; set; }
    }
}
