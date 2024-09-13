using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace VendedorAPI.Controllers
{
    [ApiController]
    [Route("api/vendedor")]
    public class VendedorController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public VendedorController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpPost("procesar-pago")]
        public async Task<IActionResult> ProcesarPago([FromBody] Tarjeta tarjeta)
        {
            // URL de la Pasarela de Pago
            var urlPasarela = "https://tu-dominio-o-ip/api/pasarela/intento-pago"; 

            // Enviar los datos de la tarjeta a la Pasarela de Pago
            var response = await _httpClient.PostAsJsonAsync(urlPasarela, tarjeta);

            // Procesar la respuesta de la Pasarela de Pago
            if (response.IsSuccessStatusCode)
            {
                return Ok(new { mensaje = "Pago procesado exitosamente" });
            }
            else
            {
                return BadRequest(new { mensaje = "El pago no fue exitoso" });
            }
        }
    }

    // Modelo para los datos de la tarjeta
    public class Tarjeta
    {
        public string Numero { get; set; }
        public string Nombre { get; set; }
        public string CVV { get; set; }
        public string FechaExpiracion { get; set; }
    }
}
