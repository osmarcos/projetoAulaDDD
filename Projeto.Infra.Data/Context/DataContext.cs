using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Infra.Data.Mappings;
using Projeto.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Projeto.Infra.Data.Context
{
    //REGRA 1) Herdar DbContext
    public class DataContext : DbContext
    {
        //contrutor -> ctor + 2x[tab]
        public DataContext(DbContextOptions<DataContext>builder)
            :base(builder) //construtor da superclasse (classe-pai)
        {

        }

        //REGRA 2) sobrescrever o método OnModelCreating (DbContext)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //adicionar cada classe mapeada no projeto
            modelBuilder.ApplyConfiguration(new FuncaoMap());
            modelBuilder.ApplyConfiguration(new FuncionarioMap());
        }

        //REGRA 3) Declarar uma propriedade set/get para cada entidade
        //utilizando a classe DBSet do EntityFramework (LAMBDA)
        public DbSet<Funcao> Funcao { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
    }
}
