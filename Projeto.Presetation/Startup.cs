using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Projeto.Application.Contracts;
using Projeto.Application.Mappings;
using Projeto.Application.Services;
using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Services;
using Projeto.Infra.Data.Context;
using Projeto.Infra.Data.Repositories;
using Swashbuckle.AspNetCore.Swagger;

namespace Projeto.Presetation
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //mapeamento da injeção de dependência
            services.AddDbContext<DataContext>(options
                => options.UseSqlServer(Configuration.GetConnectionString("Aula")));

            //mapeamento das demais interfaces / classes
            services.AddTransient<IFuncaoAppService, FuncaoAppService>();
            services.AddTransient<IFuncionarioAppService, FuncionarioAppService>();

            //camada 'Domain'
            services.AddTransient<IFuncaoDomainService, FuncaoDomainService>();
            services.AddTransient<IFuncionarioDomainService, FuncionarioDomainService>();

            //camada 'Infra.Data'
            services.AddTransient<IFuncaoRepository, FuncaoRepository>();
            services.AddTransient<IFuncionarioRepository, FuncionarioRepository>();

            AutoMapperConfig.Register();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //configuração para gerar a documentação do Swagger
            //configurando o Swagger
            services.AddSwaggerGen(
                swagger =>
                {
                    swagger.SwaggerDoc("v1",
                        new Info
                        {
                            Title = "Controle de Funcionários - C# WebDeveloper COTI Informática",
                            Description = "Projeto desenvolvido em aula",
                            Version = "v1",
                            Contact = new Contact
                            {
                                Name = "COTI Informática",
                                Email = "contato@cotiinformatica.com.br",
                                Url = "http://www.cotiinformatica.com.br"
                            }
                        });
                }
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseSwagger(); //ativiando o swagger
            app.UseSwaggerUI(s => { s.SwaggerEndpoint("/swagger/v1/swagger.json", "Aula"); });
        }
    }
}
