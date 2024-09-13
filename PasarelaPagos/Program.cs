using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace PasarelaDePagoAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();  // Especificar que se usará el Startup.cs para la configuración
                });
    }
}
