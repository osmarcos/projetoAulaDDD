using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Domain.Entities;

namespace Projeto.Domain.Contracts.Repositories
{
    public interface IFuncionarioRepository
        : IBaseRepository<Funcionario>
    {
        List<Funcionario> SelectAll(string nome);

        List<Funcionario> SelectAll(decimal salarioMin, decimal salarioMax);
    }
}
