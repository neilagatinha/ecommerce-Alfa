using Microsoft.AspNetCore.Identity;

namespace ecommerce_db.Models
{
  
        public class AppUser : IdentityUser
        {
            public string Nome { get; set;  }
        }
}
