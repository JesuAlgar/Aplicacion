using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        // Habilitar CORS para permitir solicitudes desde la API del Vendedor
        services.AddCors(options =>
        {
            options.AddPolicy("PermitirVendedorAPI", builder =>
            {
                builder.WithOrigins("https://localhost:5002")  // Cambia por el puerto del VendedorAPI
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

        // Aplicar la política de CORS para la comunicación con el VendedorAPI
        app.UseCors("PermitirVendedorAPI");

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
