using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Yet.Infrastructure.Data;
using Yet.Infrastructure.Identity;

namespace Yet.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args)
                  .Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                try
                {
                    // Instancia o serviço para o contexto do catálogo
                    var catalogoContext = services.GetRequiredService<CatalogoContexto>();
                    await CatalogoContextoSeed.SeedAsync(catalogoContext, loggerFactory);

                    var userManager = services.GetRequiredService<UserManager<UsuarioApp>>();
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                    await AutenticacaoContextoSeed.SeedAsync(userManager, roleManager);
                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex, "Erro durante a tentativa de popular o banco de dados com 'Seeds'.");
                }
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
