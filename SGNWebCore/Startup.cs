using Data.EF;
using DI;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SGNWebCore.HttpClients;
using System;

namespace SGNWebCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        //método usado para configurar os diferentes serviços como Entity Framework, Identity, etc usados na aplicação.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/Account/Login";
            });

            services.AddHttpContextAccessor();

            services.AddHttpClient<AccountApiClient>(client =>
            {
                client.BaseAddress = new Uri("http://localhost:5000/sgnwebcoreapi/");
            });

            services.AddHttpClient<ClientesApiClient>(client =>
            {
                client.BaseAddress = new Uri("http://localhost:5000/sgnwebcoreapi/");
            });

            services.AddHttpClient<EquipamentosApiClient>(client => {
                client.BaseAddress = new Uri("http://localhost:5000/sgnwebcoreapi/");
            });

            services.AddHttpClient<TiposEquipamentosApiClient>(client => {
                client.BaseAddress = new Uri("http://localhost:5000/sgnwebcoreapi/");
            });

            services.AddMvc();

        }

        //método usado para configurar o pipeline de tratamento das requisições usando um middleware.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
