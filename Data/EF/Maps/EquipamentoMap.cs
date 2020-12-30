using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EF.Maps
{
    public class EquipamentoMap : IEntityTypeConfiguration<Equipamento>
    {
        public void Configure(EntityTypeBuilder<Equipamento> builder)
        {
            builder.ToTable(nameof(Equipamento));

            builder.HasKey(pk => pk.Id);

            builder.Property(p => p.Marca)
               .HasColumnType("varchar(100)")
               .IsRequired();

            builder.Property(p => p.Modelo)
               .HasColumnType("varchar(100)");

            builder.Property(p => p.NumSerie)
              .HasColumnType("varchar(100)");

            builder.Property(p => p.Descricao)
              .HasColumnType("varchar(100)");

            builder.Property(c => c.DataCriacao);

            builder.Property(c => c.DataAlteracao);
        }
    }
}
