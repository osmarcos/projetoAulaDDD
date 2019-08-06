using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Contracts.Services;

namespace Projeto.Domain.Services
{
    public class BaseDomainService<T> : IBaseDomainService<T>
        where T : class
    {
        //atributo
        private readonly IBaseRepository<T> repository;

        //contrutor para injeção de dependência
        public BaseDomainService(IBaseRepository<T> repository)
        {
            this.repository = repository;
        }

        public virtual void Cadastrar(T obj)
        {
            repository.Insert(obj);
        }

        public virtual void Atualizar(T obj)
        {
            repository.Update(obj);
        }

        public virtual void Excluir(int id)
        {
            repository.Delete(id);
        }

        public virtual List<T> ConsultarTodos()
        {
            return repository.SelectAll();
        }

        public virtual T ConsultarPorId(int id)
        {
            return repository.SelectById(id);
        }
    }
}
