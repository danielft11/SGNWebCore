using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EF.Maps
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable(nameof(Endereco));

            builder.HasKey(pk => pk.Id);

            builder.Property(p => p.Logradouro)
             .HasColumnType("varchar(100)")
             .IsRequired();

            builder.Property(p => p.Numero)
             .HasColumnType("varchar(6)")
             .IsRequired();

            builder.Property(p => p.Complemento)
             .HasColumnType("varchar(50)");
  
            builder.Property(p => p.Bairro)
             .HasColumnType("varchar(20)")
             .IsRequired();

            builder.Property(p => p.Cidade)
             .HasColumnType("varchar(40)")
             .IsRequired();

            builder.Property(p => p.Estado)
             .HasColumnType("varchar(2)")
             .IsRequired();

            builder.Property(p => p.CEP)
             .HasColumnType("varchar(8)");
        }
    }
}
