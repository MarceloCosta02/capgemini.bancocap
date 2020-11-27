using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apibanco.Configuration;
using apibanco.Interfaces.Repository;
using apibanco.Interfaces.Service;
using apibanco.Repository;
using apibanco.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace apibanco
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
            services.AddControllers();
            services.ConfigurarSwagger();

            
            // Inje��o de depend�ncia dos Repositories
            services.AddSingleton<IClientRepository, ClientRepository>();
            services.AddSingleton<IAccountRepository, AccountRepository>();
            
            // Inje��o de depend�ncia dos Services
            services.AddSingleton<IClientService, ClientService>();
            services.AddSingleton<IAccountService, AccountService>();

            services.AddControllers().AddNewtonsoftJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UtilizarConfiguracaoSwagger();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
