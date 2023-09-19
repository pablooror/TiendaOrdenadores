using ComponentesMVC.Data.Logs;
using ComponentesMVC.Models;
using ComponentesMVC.Services;
using Microsoft.EntityFrameworkCore;
using NLog;
using Polly.Extensions.Http;
using Polly;
using ComponentesMVC.API;

namespace ComponentesMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Directory.GetCurrentDirectory());
            var logger = LogManager.Setup().LoadConfigurationFromFile().GetCurrentClassLogger();
            logger.Debug("init main");

            var builder = WebApplication.CreateBuilder(args);

            //Servicios del Logger
            LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            builder.Services.AddSingleton<ILoggerManager, LoggerManager>();

            builder.Services.AddHttpClient("MyHttpClient")
                .AddPolicyHandler(GetCircuitBreakerPolicy());

            //Servicios del repositorio
            builder.Services.AddScoped<IRepositorioComponente, RepositorioComponenteAPI>();
            builder.Services.AddScoped<IRepositorioOrdenador, RepositorioOrdenadorAPI>();
            builder.Services.AddScoped<IRepositorioPedido, RepositorioPedidoAPI>();
            builder.Services.AddScoped<IRepositorioFactura, RepositorioFacturaAPI>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var dataDirectory = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\.."));
            builder.Services.AddDbContext<TiendaOrdenadoresContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default").
                    Replace("|DataDirectory|", dataDirectory)));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }

        private static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .CircuitBreakerAsync(
                    handledEventsAllowedBeforeBreaking: 3,
                    durationOfBreak: TimeSpan.FromSeconds(30)
                );
        }
    }
}