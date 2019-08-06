using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Projeto.Domain.Entities;
using Projeto.Domain.Contracts.Services;
using Projeto.Application.Contracts;
using Projeto.Application.ViewModels;

namespace Projeto.Application.Services
{
    public class FuncaoAppService : IFuncaoAppService
    {
        //atributo
        private readonly IFuncaoDomainService domainService;

        //contrutor para injeção de dependência
        public FuncaoAppService(IFuncaoDomainService domainService)
        {
            this.domainService = domainService;
        }

        public void Cadastrar(FuncaoCadastroViewModel model)
        {
            var funcao = Mapper.Map<Funcao>(model);
            domainService.Cadastrar(funcao);
        }

        public void Atualizar(FuncaoEdicaoViewModel model)
        {
            var funcao = Mapper.Map<Funcao>(model);
            domainService.Atualizar(funcao);
        }

        public void Excluir(int idFuncao)
        {
            domainService.Excluir(idFuncao);
        }

        public List<FuncaoConsultaViewModel> ConsultarTodos()
        {
            var lista = domainService.ConsultarTodos();
            var model = Mapper.Map<List<FuncaoConsultaViewModel>>(lista);

            return model;
        }

        public FuncaoConsultaViewModel ConsultarPorId(int idFuncao)
        {
            var funcao = domainService.ConsultarPorId(idFuncao);
            var model = Mapper.Map<FuncaoConsultaViewModel>(funcao);

            return model;
        }
    }
}
