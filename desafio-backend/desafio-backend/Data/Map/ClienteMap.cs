using desafio_backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace desafio_backend.Data.Map
{
    public class ClienteMap : IEntityTypeConfiguration<ClienteEmpresarialModel>
    {
        public void Configure(EntityTypeBuilder<ClienteEmpresarialModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.RazaoSocial).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Cnpj).IsRequired().HasMaxLength(14);
            builder.Property(x => x.Endereco).IsRequired().HasMaxLength(255);
        }
    }
}
