using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Entities;
using SocialMedia.Infrastructure.Persistence.Mappings;

namespace SocialMedia.Infrastructure.Persistence
{
    public class SocialMediaDbContext : DbContext
    {
        public SocialMediaDbContext(DbContextOptions<SocialMediaDbContext> options)
            : base(options)
        {

        }

        public DbSet<Conta> Contas { get; set; }
        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<Publicacao> Publicacoes { get; set; }
        public DbSet<Conexao> Conexoes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfiguration(new ContaMap());

            builder.Entity<Perfil>(e =>
            {
                e.HasKey(p => p.Id);

                e.HasMany(p => p.Publicacoes)
                    .WithOne(u => u.Perfil)
                    .HasForeignKey(u => u.IdPerfil)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Publicacao>(e =>
            {
                e.HasKey(p => p.Id);
            });


            builder.Entity<Conexao>(e =>
            {
                e.HasKey(c => c.Id);
            });


            base.OnModelCreating(builder);
        }
    }
}
