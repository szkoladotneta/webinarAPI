using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebinarAPI.Domain.Model;

namespace WebinarAPI.Domain.Interfaces
{
    public interface IDbContext
    {
        DbSet<Present> Presents { get; set; }
        DbSet<WishList> Wishlists { get; set; }

        Task<int> SaveChangesAsync();
    }
}
