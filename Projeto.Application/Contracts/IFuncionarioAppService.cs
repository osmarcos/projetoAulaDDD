using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Application.ViewModels;

namespace Projeto.Application.Contracts
{
    public interface IFuncionarioAppService
    {
        void Cadastrar(FuncionarioCadastroViewModel model);
        void Atualizar(FuncionarioEdicaoViewModel model);
        void Excluir(int idFuncionario);

        List<FuncionarioConsultaViewModel> ConsultarTodos();
        FuncionarioConsultaViewModel ConsultarPorId(int idFuncionario);
    }
}
