using AutoMapper;
using WebinarAPI.Application.Mapping;
using WebinarAPI.Domain.Model;

namespace WebinarAPI.Application.ViewModels.Presents
{
    public class PresentDto : IMapFrom<Present>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TypeName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Present, PresentDto>()
                .ForMember(d => d.TypeName, opt => opt.MapFrom(src => src.PresentType.Name));
        }
    }
}
