using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using WebinarAPI.Application.Interfaces;
using WebinarAPI.Application.ViewModels.Wishlists;

namespace WebinarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WishlistController : ControllerBase
    {
        private readonly IWishlistService _wishlistService;
        public WishlistController(IWishlistService wishlistService)
        {
            _wishlistService = wishlistService;
        }

        [HttpGet("Search/{username}")]
        [Description("Return list for searched username")]
        public async Task<ActionResult<WishlistsVm>> Get(string username)
        {
            var wishlists = await _wishlistService.GetWishlistByUserName(username);
            return Ok(wishlists);
        }
    }
}
