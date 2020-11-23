using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebinarAPI.Application.Mapping;
using WebinarAPI.Domain.Model;

namespace WebinarAPI.Application.ViewModels.Presents
{
    public class CreatePresentDto : IMapFrom<Present>
    {
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePresentDto, Present>();
        }
    }
}
