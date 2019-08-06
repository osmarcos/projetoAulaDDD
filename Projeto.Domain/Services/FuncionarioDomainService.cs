using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Domain.Entities;
using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Contracts.Services;

namespace Projeto.Domain.Services
{
    public class FuncionarioDomainService 
        : BaseDomainService<Funcionario>, IFuncionarioDomainService
    {
        //atributo
        private readonly IFuncionarioRepository repository;

        //contrutor para injeção de dependência
        public FuncionarioDomainService(IFuncionarioRepository repository)
            : base(repository)
        {
            this.repository = repository;
        }

        public List<Funcionario> ConsultarTodos(string nome)
        {
            return repository.SelectAll(nome);
        }

        public List<Funcionario> ConsultarTodos(decimal salarioMin, decimal salarioMax)
        {
            return repository.SelectAll(salarioMin, salarioMax);
        }
    }
}
