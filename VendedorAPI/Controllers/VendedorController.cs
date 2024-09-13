using Microsoft.AspNetCore.Mvc;

namespace VendedorAPI.Controllers
{
    [ApiController]
    [Route("api/vendedor")]
    public class VendedorController : ControllerBase
    {
        [HttpPost("procesar-pago")]
        public IActionResult ProcesarPago([FromBody] Tarjeta tarjeta)
        {
            // Aquí puedes colocar la lógica de procesamiento de la tarjeta
            return Ok(new { mensaje = "Pago procesado exitosamente" });
        }
    }

    // Clase para representar la tarjeta
    public class Tarjeta
    {
        public string Numero { get; set; }
        public string Nombre { get; set; }
        public string CVV { get; set; }
        public string FechaExpiracion { get; set; }
    }
}
