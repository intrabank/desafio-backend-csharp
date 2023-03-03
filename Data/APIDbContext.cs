using APIDesafioIntrabank.Model;
using Microsoft.EntityFrameworkCore;

namespace APIDesafioIntrabank.Data
{
    public class APIDbContext : DbContext
    {
        public DbSet<ClienteEmpresarial> ClientesEmpresariais { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<User> Users { get; set; }
        public APIDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClienteEmpresarial>()
                .HasOne(c => c.Endereco)
                .WithOne(e => e.ClienteEmpresarial)
                .HasForeignKey<ClienteEmpresarial>(c => c.EnderecoId);
        }

    }
}
