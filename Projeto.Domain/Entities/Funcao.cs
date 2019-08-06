using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Entities
{
    public class Funcao
    {
        public int IdFuncao { get; set; }
        public string Descricao { get; set; }

        //Associação TER-MUITOS
        public List<Funcionario> Funcionarios { get; set; }
    }
}
