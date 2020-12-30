using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EF.Maps
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable(nameof(Cliente));

            builder.HasKey(pk => pk.Id);

            builder.Property(p => p.TipoCliente)
               .HasColumnType("varchar(15)")
              .IsRequired();

            builder.Property(p => p.Nome)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(p => p.CPF)
             .HasColumnType("varchar(11)");

            builder.Property(p => p.RG)
             .HasColumnType("varchar(14)");

            builder.Property(p => p.Sexo)
                .HasColumnType("varchar(10)");

            builder.Property(p => p.CelPrincipal)
            .HasColumnType("varchar(11)");

            builder.Property(p => p.Cel2)
            .HasColumnType("varchar(11)");

            builder.Property(p => p.Telefone)
                .HasColumnType("varchar(10)");

            builder.Property(p => p.Email)
                .HasColumnType("varchar(100)");

            builder.Property(p => p.CNPJ)
             .HasColumnType("varchar(14)");

            builder.Property(p => p.RazaoSocial)
            .HasColumnType("varchar(300)");

            builder.Property(p => p.InscEstadual)
             .HasColumnType("varchar(14)");

            builder.Property(p => p.Observacoes)
            .HasColumnType("varchar(300)");

            builder.Property(p => p.DataCriacao);

            builder.Property(p => p.DataAlteracao);

        }
    }
}
