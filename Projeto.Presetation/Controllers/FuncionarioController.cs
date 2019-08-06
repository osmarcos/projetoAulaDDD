using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Application.Contracts;
using Projeto.Application.ViewModels;

namespace Projeto.Presetation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        //atributo
        private readonly IFuncionarioAppService appService;

        //construtor para injeção de dependência
        public FuncionarioController(IFuncionarioAppService appService)
        {
            this.appService = appService;
        }

        [HttpPost]
        public IActionResult Post([FromBody]FuncionarioCadastroViewModel model)
        {
            if (!ModelState.IsValid) //se não passaram nas regras de validação
            {
                return BadRequest(); //status de erro 400
            }

            try
            {
                appService.Cadastrar(model);
                return Ok($"Funcionario '{model.Nome}', cadastrado com sucesso.");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody]FuncionarioEdicaoViewModel model)
        {
            if (!ModelState.IsValid) //se não passaram nas regras de validação
            {
                return BadRequest(); //status de erro 400
            }

            try
            {
                appService.Atualizar(model);
                return Ok($"Funcionario '{model.Nome}', atualizado com sucesso.");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                appService.Excluir(id);
                return Ok($"Funcionario excluído com sucesso.");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(appService.ConsultarTodos());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetPorId(int id)
        {
            try
            {
                return Ok(appService.ConsultarPorId(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}