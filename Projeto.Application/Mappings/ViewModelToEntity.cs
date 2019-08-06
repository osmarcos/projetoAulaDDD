using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Domain.Entities;
using Projeto.Application.ViewModels;
using AutoMapper;

namespace Projeto.Application.Mappings
{
    public class ViewModelToEntity : Profile
    {
        //contrutor
        public ViewModelToEntity()
        {
            #region Função

            CreateMap<FuncaoCadastroViewModel, Funcao>();
            CreateMap<FuncaoEdicaoViewModel, Funcao>();

            #endregion

            #region Funcionário

            CreateMap<FuncionarioCadastroViewModel, Funcionario>();
            CreateMap<FuncionarioEdicaoViewModel, Funcionario>();

            #endregion
        }
    }
}
