using Microsoft.AspNetCore.Mvc;
using VendedorAPI.Models;
using System.Net.Http;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class VendedorController : ControllerBase
{
    private readonly HttpClient _httpClient;

    public VendedorController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    [HttpPost("comprarProducto")]
    public async Task<IActionResult> ComprarProducto([FromBody] ProductoRequest request)
    {
        var pago = new PagoRequest
        {
            Cliente = request.Cliente,
            Vendedor = new Vendedor { Nombre = "Tienda XYZ", Email = "vendedor@xyz.com" },
            DetallesPago = request.DetallesPago
        };

        // Actualiza la URL para apuntar a tu pasarela de pagos alojada en Azure
        var response = await _httpClient.PostAsJsonAsync(
            "https://mi-pasarela-de-pago-frf6arf9gsfvcahw.spaincentral-01.azurewebsites.net/api/payment/procesarPago",
            pago
        );

        if (response.IsSuccessStatusCode)
        {
            return Ok(new { mensaje = "Compra exitosa" });
        }

        return BadRequest(new { mensaje = "Error en el pago" });
    }
}
