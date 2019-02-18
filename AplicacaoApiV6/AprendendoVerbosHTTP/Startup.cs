using AprendendoVerbosHTTP.Repository;
using AprendendoVerbosHTTP.Repository.Implementations;
using AprendendoVerbosHTTP.Model.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using AprendendoVerbosHTTP.Repository.Generic;
using AprendendoVerbosHTTP.Business;
using AprendendoVerbosHTTP.Business.Implementations;
using Microsoft.Net.Http.Headers;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Rewrite;

namespace AprendendoVerbosHTTP
{
    public class Startup
    {
        private readonly ILogger _logger;
        public IConfiguration _configuration { get; }
        public IHostingEnvironment _environment { get; } 

        public Startup(IConfiguration configuration, IHostingEnvironment environment, ILogger<Startup> logger)
        {
            _logger = logger;
            _configuration = configuration;
            _environment = environment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //Configurações para acesso a banco de dados
            var conexaoString = _configuration["MySqlConnection:MySqlConnectionString"];
            services.AddDbContext<MySQLContext>(options => options.UseMySql(conexaoString));

            if (_environment.IsDevelopment())
            {
                try
                {
                    //Adicionando o envolve (migrations)
                    var evolveConnection = new MySql.Data.MySqlClient.MySqlConnection(conexaoString);
                    var evolve = new Evolve.Evolve("evolve.json", evolveConnection, msg => _logger.LogInformation(msg))
                    {
                        Locations = new List<string> { "db/migrations", "db/dataset" },
                        IsEraseDisabled = true
                    };

                    evolve.Migrate();


                }
                catch(Exception ex)
                {
                    _logger.LogCritical("Database Migration Failed", ex);
                    throw;
                }
            }

            //Adicionando outros padrões de reposta como xml e json
            services.AddMvc(options =>
            {

                options.RespectBrowserAcceptHeader = true;
                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("text/xml"));
                options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));

            }).AddXmlSerializerFormatters().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //Adicionando o Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "RESTful API com ASP.NET", Version = "v1" });
            });

            //Adicionando dependências
            services.AddScoped<IPessoaBusiness, PessoaBusinessImpl>();
            services.AddScoped<ILivroBusiness, LivroBusinessImpl>();
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

            //Adicionando Versionamento
            services.AddApiVersioning();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c => 
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API V1");
            });

            var options = new RewriteOptions();
            options.AddRedirect("^$", "swagger");
            app.UseRewriter(options);

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
