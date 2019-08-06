using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Application.ViewModels
{
    public class FuncaoEdicaoViewModel
    {
        [Required(ErrorMessage = "Informe o Id da função.")]
        public string IdFunccao { get; set; }

        [Required(ErrorMessage = "Informe a descrição.")]
        public string Descricao { get; set; }
    }
}
