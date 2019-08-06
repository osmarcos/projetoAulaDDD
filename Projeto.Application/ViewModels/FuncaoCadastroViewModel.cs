using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Application.ViewModels
{
    public class FuncaoCadastroViewModel
    {
        [Required(ErrorMessage = "Informe a descrição.")]
        public string Descricao { get; set; }
    }
}
