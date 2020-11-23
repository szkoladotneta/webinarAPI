using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebinarAPI.Application.Mapping;
using WebinarAPI.Application.ViewModels.Presents;
using WebinarAPI.Domain.Model;

namespace WebinarAPI.Application.ViewModels.Wishlists
{
    public class WishlistDto : IMapFrom<WishList>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public List<PresentDto> Presents { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<WishList, WishlistDto>()
                .ForMember(d => d.UserName, opt => opt.MapFrom(src => src.ApplicationUser.UserName));
        }
    }
}
