using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace VendedorAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Configura los servicios para la aplicación
        public void ConfigureServices(IServiceCollection services)
        {
            // Agregar soporte para controladores y el uso de HttpClient
            services.AddControllers();
            services.AddHttpClient();  // HttpClient será utilizado para hacer solicitudes a la Pasarela de Pago
        }

        // Configuración del pipeline de la aplicación
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();  // Forzar redirección de HTTP a HTTPS
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();  // Habilitar controladores
            });
        }
    }
}
