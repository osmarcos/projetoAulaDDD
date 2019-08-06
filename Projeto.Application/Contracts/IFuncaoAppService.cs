using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Application.ViewModels;

namespace Projeto.Application.Contracts
{
    public interface IFuncaoAppService
    {
        void Cadastrar(FuncaoCadastroViewModel model);
        void Atualizar(FuncaoEdicaoViewModel model);
        void Excluir(int idFuncao);

        List<FuncaoConsultaViewModel> ConsultarTodos();
        FuncaoConsultaViewModel ConsultarPorId(int idFuncao);
    }
}
