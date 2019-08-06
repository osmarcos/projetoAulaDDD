using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Domain.Entities;
using Projeto.Domain.Contracts.Repositories;
using Projeto.Infra.Data.Context;

namespace Projeto.Infra.Data.Repositories
{
    public class FuncaoRepository 
        : BaseRepository<Funcao>, IFuncaoRepository
    {
        //atributo
        private readonly DataContext context;

        //criando um construtor para injeção de dependência
        public FuncaoRepository(DataContext context) : base(context)
        {
            this.context = context;
        }
    }
}
