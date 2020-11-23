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
    public class UpdatePresentDto : IMapFrom<Present>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdatePresentDto, Present>();
        }
    }
}
