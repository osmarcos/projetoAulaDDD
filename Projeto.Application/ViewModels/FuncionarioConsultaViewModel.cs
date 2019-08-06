using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.ViewModels
{
    public class FuncionarioConsultaViewModel
    {
        public int IdFuncionario { get; set; }
        public string Nome { get; set; }
        public decimal Salario { get; set; }
        public DateTime DataAdmissao { get; set; }
        public int IdFuncao { get; set; }

        public FuncaoConsultaViewModel Funcao { get; set; }
    }
}
