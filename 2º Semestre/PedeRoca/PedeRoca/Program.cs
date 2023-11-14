using PedeRoca.Integracao.Refit;
using System.Security.Policy;
using Refit;
using PedeRoca.Integracao.Interfaces;
using PedeRoca.Integracao;

namespace PedeRoca
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // API - Correios
            #region "API -> Correios"
            builder.Services.AddScoped<IViaCepIntegracao, ViaCepIntegracao>();

            builder.Services.AddRefitClient<IViaCepIntegracaoRefit>().ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri("https://viacep.com.br");
            });
            #endregion

            //Controle - Sessão
            #region "Serviço de gerênciamento de seção"
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddScoped<Services.ISessao, Services.Sessao>();
            //Controle de seção
            builder.Services.AddSession(options =>
            {
                //Propriedade idleTimeOut refere-se ao tempo de expiração da seção por inatividade. O tempo parão é de uma aplicação asp .net core é de 20 minutos.
                options.IdleTimeout = TimeSpan.FromMinutes(10); //personaliza o tempo da seção -> Depois de 10 minutos encerra a seção
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            //Adiciona usa da seção
            #region "Adiciona o uso da seção"
            app.UseSession();
            #endregion

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Produto}/{action=Index}/{id?}");

            app.Run();
        }
    }
}