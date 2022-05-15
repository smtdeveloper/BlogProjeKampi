using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class AppUser : IdentityUser
    {
        public string NameSurname { get; set; }
        public string ImageUrl { get; set; }
    }
}
