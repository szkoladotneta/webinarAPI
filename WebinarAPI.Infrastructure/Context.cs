using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebinarAPI.Domain.Common;
using WebinarAPI.Domain.Interfaces;
using WebinarAPI.Domain.Model;

namespace WebinarAPI.Infrastructure
{
    public class Context : IdentityDbContext<ApplicationUser>, IDbContext
    {
        public DbSet<Present> Presents { get; set; }
        public DbSet<PresentType> PresentTypes { get; set; }
        public DbSet<WishList> Wishlists { get; set; }

        public Context(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }

        public async Task<int> SaveChangesAsync()
        {
 
            var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is AuditEntity && (
            e.State == EntityState.Added
            || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((AuditEntity)entityEntry.Entity).ModifiedDate = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((AuditEntity)entityEntry.Entity).CreatedDate = DateTime.Now;
                }
            }

            return await base.SaveChangesAsync(new());
        }
    }
}
