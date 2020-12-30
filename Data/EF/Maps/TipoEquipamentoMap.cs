using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EF.Maps
{
    public class TipoEquipamentoMap : IEntityTypeConfiguration<TipoEquipamento>
    {
        public void Configure(EntityTypeBuilder<TipoEquipamento> builder)
        {
            builder.ToTable(nameof(TipoEquipamento));

            builder.HasKey(pk => pk.Id);

            builder.Property(p => p.Nome)
               .HasColumnType("varchar(100)")
               .IsRequired();

            builder.Property(p => p.Descricao)
               .HasColumnType("varchar(100)");

            builder.Property(c => c.DataCriacao);

            builder.Property(c => c.DataAlteracao);
        }
    }
}
