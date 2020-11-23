using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebinarAPI.Application.Interfaces;
using WebinarAPI.Application.ViewModels.Wishlists;
using WebinarAPI.Domain.Interfaces;
using WebinarAPI.Domain.Model;

namespace WebinarAPI.Application.Services
{
    public class WishlistService : IWishlistService
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        public WishlistService(IDbContext context, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<WishlistsVm> GetWishlistByUserName(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            var wishlists = await _context.Wishlists
                .Where(p => p.ApplicationUserId == user.Id)
                .ProjectTo<WishlistDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return new() { Wishlists = wishlists, Count = wishlists.Count };
        }
    }
}
