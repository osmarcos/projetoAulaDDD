using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Application.ViewModels
{
    public class FuncionarioCadastroViewModel
    {
        [Required(ErrorMessage = "Informe o nome.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o salário.")]
        public decimal Salario { get; set; }

        [Required(ErrorMessage = "Informe a data de admissão.")]
        public DateTime DataAdmissao { get; set; }

        [Required(ErrorMessage = "Informe o ID da Função.")]
        public int IdFuncao { get; set; }
    }
}
