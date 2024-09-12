using Microsoft.AspNetCore.Mvc;
using PasarelaPagos.Models;

[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
    // Endpoint para procesar pagos (POST)
    [HttpPost("procesarPago")]
    public IActionResult ProcesarPago([FromBody] PagoRequest request)
    {
        if (EsPagoValido(request.DetallesPago))
        {
            // Si el pago es válido, devolver respuesta exitosa
            return Ok(new { mensaje = "Pago procesado con éxito" });
        }
        
        // Si hay algún error en la validación del pago, devolver BadRequest
        return BadRequest(new { mensaje = "Pago rechazado" });
    }

    // Método privado que simula la validación del pago
    private bool EsPagoValido(DetallesPago detalles)
    {
        // Simular validaciones de tarjeta de crédito (esto puede mejorarse)
        // Aquí puedes agregar validaciones reales (número de tarjeta, CVV, etc.)
        return !string.IsNullOrEmpty(detalles.NumeroTarjeta) 
               && detalles.CVV.Length == 3; // Ejemplo simple de validación
    }

    // Endpoint de prueba para verificar que la API está funcionando (GET)
    [HttpGet("prueba")]
    public IActionResult Prueba()
    {
        return Ok(new { mensaje = "API funcionando correctamente" });
    }
}
