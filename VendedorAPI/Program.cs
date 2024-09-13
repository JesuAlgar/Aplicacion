using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace VendedorAPI
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
                    webBuilder.UseStartup<Startup>();  // Especificar que usaremos la configuración de Startup.cs
                });
    }
}
