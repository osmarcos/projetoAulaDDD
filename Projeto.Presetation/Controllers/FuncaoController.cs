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
    public class FuncaoController : ControllerBase
    {
        //atributo
        private readonly IFuncaoAppService appService;

        //construtor para injeção de dependência
        public FuncaoController(IFuncaoAppService appService)
        {
            this.appService = appService;
        }

        [HttpPost]
        public IActionResult Post([FromBody]FuncaoCadastroViewModel model)
        {
            if(!ModelState.IsValid) //se não passaram nas regras de validação
            {
                return BadRequest(); //status de erro 400
            }

            try
            {
                appService.Cadastrar(model);
                return Ok($"Função '{model.Descricao}', cadastrado com sucesso.");
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody]FuncaoEdicaoViewModel model)
        {
            if (!ModelState.IsValid) //se não passaram nas regras de validação
            {
                return BadRequest(); //status de erro 400
            }

            try
            {
                appService.Atualizar(model);
                return Ok($"Função '{model.Descricao}', atualizada com sucesso.");
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
                return Ok($"Função excluída com sucesso.");
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