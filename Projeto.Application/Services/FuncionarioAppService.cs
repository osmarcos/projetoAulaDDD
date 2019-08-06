using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Projeto.Application.Contracts;
using Projeto.Application.ViewModels;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Entities;

namespace Projeto.Application.Services
{
    public class FuncionarioAppService : IFuncionarioAppService
    {
        //atributo 
        private readonly IFuncionarioDomainService domainService;

        //contrutor para injeção de dependêcia
        public FuncionarioAppService(IFuncionarioDomainService domainService)
        {
            this.domainService = domainService;
        }

        public void Cadastrar(FuncionarioCadastroViewModel model)
        {
            var funcionario = Mapper.Map<Funcionario>(model);
            domainService.Cadastrar(funcionario);
        }

        public void Atualizar(FuncionarioEdicaoViewModel model)
        {
            var funcionario = Mapper.Map<Funcionario>(model);
            domainService.Atualizar(funcionario);
        }

        public void Excluir(int idFuncionario)
        {
            domainService.Excluir(idFuncionario);
        }

        public List<FuncionarioConsultaViewModel> ConsultarTodos()
        {
            var lista = domainService.ConsultarTodos();
            var model = Mapper.Map<List<FuncionarioConsultaViewModel>>(lista);

            return model;
        }

        public FuncionarioConsultaViewModel ConsultarPorId(int idFuncionario)
        {
            var funcionario = domainService.ConsultarPorId(idFuncionario);
            var model = Mapper.Map<FuncionarioConsultaViewModel>(funcionario);

            return model;
        }
    }
}
