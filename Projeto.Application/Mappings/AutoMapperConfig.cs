using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace Projeto.Application.Mappings
{
    public class AutoMapperConfig
    {
        //método estático para executar a configuração necessária
        //para que o AutoMapper funcionar no projeto Asp.Net
        public static void Register()
        {
            Mapper.Initialize(
                cfg =>
                {
                    cfg.AddProfile<EntityToViewModel>();
                    cfg.AddProfile<ViewModelToEntity>();
                });
        }
    }
}
