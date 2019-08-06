using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Projeto.Infra.Data.Mappings
{
    public class FuncionarioMap : IEntityTypeConfiguration<Funcao>
    {

        public void Configure(EntityTypeBuilder<Funcao> builder)
        {
            builder.ToTable("FUNCAO");

            builder.HasKey(f => f.IdFuncao);

            builder.Property(f => f.IdFuncao).HasColumnName("IDFUNCAO");

            builder.Property(f => f.Descricao)
                .HasColumnName("DESCRICAO")
                .HasMaxLength(250)
                .IsRequired();
        }
    }


}
