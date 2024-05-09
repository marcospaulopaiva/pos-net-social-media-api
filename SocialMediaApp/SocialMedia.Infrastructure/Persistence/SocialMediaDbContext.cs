using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Entities;

namespace SocialMedia.Infrastructure.Persistence
{
    public class SocialMediaDbContext : DbContext
    {
        public SocialMediaDbContext(
            DbContextOptions<SocialMediaDbContext> options)
            : base(options)
        {

        }

        public DbSet<Conta> Contas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Conta>(e =>
            {
                e.HasKey(p => p.Id);
            });
        }
    }
}
