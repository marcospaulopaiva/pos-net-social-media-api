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
        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<Publicacao> Publicacoes { get; set; }
        public DbSet<Conexao> Conexoes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Conta>(e =>
            {
                e.HasKey(c => c.Id);

                e.HasMany(c => c.Perfis)
                    .WithOne(p => p.Conta)
                    .HasForeignKey(p => p.IdConta)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasMany(c => c.Conexoes)
                    .WithOne(co => co.Seguidor)
                    .HasForeignKey(co => co.IdSeguidor)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasMany(c => c.Conexoes)
                    .WithOne(co => co.Seguidor)
                    .HasForeignKey(co => co.IdSeguido)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);

            });

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
