using Microsoft.EntityFrameworkCore;
using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Entities;
using Projeto.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace Projeto.Infra.Data.Repositories
{
    public class FuncionarioRepository
        : BaseRepository<Funcionario>, IFuncionarioRepository
    {
        //atributo
        private readonly DataContext context;

        //contrutor para injeção de dependência
        public FuncionarioRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        public override List<Funcionario> SelectAll()
        {
            return context.Funcionario
                .Include(f => f.Funcao)
                .ToList();
        }

        public override Funcionario SelectById(int id)
        {
            return context.Funcionario
                .Include(f => f.Funcao)
                .SingleOrDefault(f => f.IdFuncionario == id);
        }

        public List<Funcionario> SelectAll(string nome)
        {
            return context.Funcionario
                    .Include(f => f.Funcao)
                    .Where(f => f.Nome.Contains(nome))
                    .OrderBy(f => f.Nome)
                    .ToList();
        }

        public List<Funcionario> SelectAll(decimal salarioMin, decimal salarioMax)
        {
            return context.Funcionario
                    .Include(f => f.Funcao)
                    .Where(f => f.Salario >= salarioMin && f.Salario <= salarioMax)
                    .OrderByDescending(f => f.Salario)
                    .ToList();

        }
    }
}
