namespace PasarelaDePagoAPI.Models
{
    public class Tarjeta
    {
        public string Numero { get; set; }
        public string Nombre { get; set; }
        public string CVV { get; set; }
        public string FechaExpiracion { get; set; }
    }
}
