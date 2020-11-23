using System.Collections.Generic;

namespace WebinarAPI.Application.ViewModels.Presents
{
    public class PresentsVm
    {
        public ICollection<PresentDto> Presents { get; set; }
        public int Count { get; set; }
    }
}
