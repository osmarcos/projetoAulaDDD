using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Projeto.Infra.Data.Mappings
{
    public class FuncaoMap : IEntityTypeConfiguration<Funcionario>
    {


        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.ToTable("FUNCIONARIO");

            builder.HasKey(f => f.IdFuncionario);

            builder.Property(f => f.IdFuncionario).HasColumnName("IDFUNCIONARIO");

            builder.Property(f => f.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(f => f.Salario)
                .HasColumnName("SALARIO")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(f => f.DataAdmissao)
                            .HasColumnName("DATAADMISSAO")
                            .HasColumnType("date")
                            .IsRequired();

            builder.Property(f => f.IdFuncao)
                            .HasColumnName("IDFUNCAO")
                            .IsRequired();

            //Mapeamento do relacionamento
            builder.HasOne(f => f.Funcao) //Funcionário TEM 1 Função
                .WithMany(f => f.Funcionarios) //Função TEM N Funcionários
                .HasForeignKey(f => f.IdFuncao) //chave estrangeira
                .OnDelete(DeleteBehavior.Restrict); //Não Delete Cascade!
        }
    }
}
