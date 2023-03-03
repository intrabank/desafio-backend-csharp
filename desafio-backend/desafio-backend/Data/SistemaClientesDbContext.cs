using desafio_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace desafio_backend.Data
{
    public class SistemaClientesDbContext :DbContext
    {
        public SistemaClientesDbContext(DbContextOptions<SistemaClientesDbContext> options) : base(options)
        {

        }

        public DbSet<ClienteEmpresarialModel> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
