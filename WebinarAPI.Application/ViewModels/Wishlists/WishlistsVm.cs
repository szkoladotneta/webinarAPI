using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebinarAPI.Application.ViewModels.Wishlists
{
    public class WishlistsVm
    {
        public ICollection<WishlistDto> Wishlists { get; set; }
        public int Count { get; set; }
    }
}
