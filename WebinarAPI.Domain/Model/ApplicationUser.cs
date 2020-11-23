using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebinarAPI.Domain.Model
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<WishList> WishLists { get; set; }
    }
}
