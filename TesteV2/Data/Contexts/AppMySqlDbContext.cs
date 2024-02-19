using Microsoft.EntityFrameworkCore;
using TesteV2.Entities;
using TesteV2.Data.Queries;

namespace TesteV2.Data.Contexts
{
    public class AppMySqlDbContext : DbContext
    {
        public AppMySqlDbContext(DbContextOptions options ) : base( options ) { }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<PessoasFisicas> PessoasFisicas { get; set; }
        public DbSet<Enderecos> Enderecos { get; set; }
        public DbSet<Contatos> Contatos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PessoasFisicas>()
                        .HasMany(x => x.Enderecos)
                        .WithOne(x => x.PessoaFisica)
                        .HasForeignKey(x => x.PessoasFisicasId)
                        .HasPrincipalKey(x => x.Id);

            modelBuilder.Entity<PessoasFisicas>()
                        .HasMany(x => x.Contatos)
                        .WithOne(x => x.PessoaFisica)
                        .HasForeignKey(x => x.PessoasFisicasId)
                        .HasPrincipalKey(x => x.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
