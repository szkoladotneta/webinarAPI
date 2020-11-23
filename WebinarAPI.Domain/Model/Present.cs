using System.Collections.Generic;
using WebinarAPI.Domain.Common;

namespace WebinarAPI.Domain.Model
{
    public class Present : AuditEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PresentTypeId { get; set; }

        public PresentType PresentType { get; set; }
        public ICollection<WishList> WishLists { get; set; }
    }
}
