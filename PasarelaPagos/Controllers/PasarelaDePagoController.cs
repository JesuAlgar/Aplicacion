using Microsoft.AspNetCore.Mvc;

namespace PasarelaDePagoAPI.Controllers
{
    [ApiController]
    [Route("api/pasarela")]
    public class PasarelaDePagoController : ControllerBase
    {
        [HttpPost("intento-pago")]
        public IActionResult IntentoPago([FromBody] Tarjeta tarjeta)
        {
            // Simulación de la lógica de validación de la tarjeta
            if (EsTarjetaValida(tarjeta))
            {
                return Ok(new { mensaje = "Pago aprobado" });
            }
            else
            {
                return BadRequest(new { mensaje = "Pago rechazado" });
            }
        }

        // Lógica simple para validar la tarjeta
        private bool EsTarjetaValida(Tarjeta tarjeta)
        {
            // Simulación: todas las tarjetas que comienzan con "4" son válidas
            if (tarjeta.Numero.StartsWith("4"))
            {
                return true; // Tarjeta válida
            }
            return false; // Tarjeta inválida
        }
    }

    // Modelo para la tarjeta de pago
    public class Tarjeta
    {
        public string Numero { get; set; }
        public string Nombre { get; set; }
        public string CVV { get; set; }
        public string FechaExpiracion { get; set; }
    }
}
