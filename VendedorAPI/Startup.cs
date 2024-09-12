using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        // Configurar HttpClient para hacer solicitudes a la Pasarela de Pagos
        services.AddHttpClient();

        // Habilitar CORS para permitir solicitudes del cliente (por ejemplo, desde localhost)
        services.AddCors(options =>
        {
            options.AddPolicy("PermitirLocalhost", builder =>
            {
                builder.WithOrigins("https://localhost:3000")  // Cambia por el puerto del cliente si es necesario
                       .AllowAnyHeader()
                       .AllowAnyMethod();
            });
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        // Aplicar la política de CORS para localhost
        app.UseCors("PermitirLocalhost");

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
