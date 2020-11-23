using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebinarAPI.Domain.Common;

namespace WebinarAPI.Domain.Model
{
    public class WishList : AuditEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ApplicationUserId { get; set; }
        public ICollection<Present> Presents { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
