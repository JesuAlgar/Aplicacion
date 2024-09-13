using PasarelaDePagoAPI.Models;

namespace PasarelaDePagoAPI.Services
{
    public class ValidarPagoService
    {
        public bool ValidarTarjeta(Tarjeta tarjeta)
        {
            // Lógica simple para validar una tarjeta de ejemplo
            return tarjeta.Numero.StartsWith("4");  // Solo las tarjetas que empiezan con "4" son válidas
        }
    }
}
