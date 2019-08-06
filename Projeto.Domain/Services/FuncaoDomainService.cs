using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Domain.Entities;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Contracts.Repositories;

namespace Projeto.Domain.Services
{
    public class FuncaoDomainService 
        : BaseDomainService<Funcao>, IFuncaoDomainService
    {
        //atributo
        private readonly IFuncaoRepository repository;

        //construtor para injeção de dependência
        public FuncaoDomainService(IFuncaoRepository repository)
            : base(repository)
        {
            this.repository = repository;
        }
    }
}
