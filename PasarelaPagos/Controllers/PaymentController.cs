using Microsoft.AspNetCore.Mvc;

namespace PasarelaDePagosAPI.Controllers
{
    [ApiController]
    [Route("api/pasarela")]
    public class PasarelaDePagosController : ControllerBase
    {
        [HttpPost("intento-pago")]
        public IActionResult IntentoPago([FromBody] Tarjeta tarjeta)
        {
            // Lógica para validar los datos de la tarjeta (simulada)
            if (EsTarjetaValida(tarjeta))
            {
                return Ok(new { mensaje = "Pago aprobado" });
            }
            else
            {
                return BadRequest(new { mensaje = "Pago rechazado" });
            }
        }

        private bool EsTarjetaValida(Tarjeta tarjeta)
        {
            // Aquí se podría agregar lógica para validar la tarjeta
            // Por ejemplo, validar longitud del número de tarjeta, formato de fecha, etc.
            // Simulamos que todas las tarjetas que empiezan con "4" son válidas.

            if (tarjeta.Numero.StartsWith("4"))
            {
                return true; // Tarjeta válida
            }
            return false; // Tarjeta rechazada
        }
    }

    // Clase de la tarjeta
    public class Tarjeta
    {
        public string Numero { get; set; }
        public string Nombre { get; set; }
        public string CVV { get; set; }
        public string FechaExpiracion { get; set; }
    }
}
