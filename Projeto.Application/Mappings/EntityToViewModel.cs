using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Domain.Entities;
using Projeto.Application.ViewModels;
using AutoMapper;

namespace Projeto.Application.Mappings
{
    public class EntityToViewModel : Profile
    {
        //contrutor
        public EntityToViewModel()
        {
            #region Função

            CreateMap<Funcao, FuncaoConsultaViewModel>();

            #endregion

            #region Funcionario

            CreateMap<Funcionario, FuncionarioConsultaViewModel>();

            #endregion
        }
    }
}
