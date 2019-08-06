using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Contracts.Services
{
    public interface IBaseDomainService<T>
        where T : class
    {
        void Cadastrar(T obj);
        void Atualizar(T obj);
        void Excluir(int id);

        List<T> ConsultarTodos();
        T ConsultarPorId(int id);
    }
}
