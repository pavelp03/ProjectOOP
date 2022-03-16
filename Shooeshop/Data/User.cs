using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Shooeshop.Data
{
    public class User : IdentityUser
    {
        
       
        public string FullName { get; set; }
    
        public Roles Role { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
