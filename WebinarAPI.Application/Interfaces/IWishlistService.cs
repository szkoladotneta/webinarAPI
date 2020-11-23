using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebinarAPI.Application.ViewModels.Wishlists;

namespace WebinarAPI.Application.Interfaces
{
    public interface IWishlistService
    {
        Task<WishlistsVm> GetWishlistByUserName(string userName);
    }
}
