using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Domain.Entities;

namespace Projeto.Domain.Contracts.Services
{
    public interface IFuncionarioDomainService : IBaseDomainService<Funcionario>
    {
        List<Funcionario> ConsultarTodos(string nome);

        List<Funcionario> ConsultarTodos(decimal salarioMin, decimal salarioMax);
    }
}
