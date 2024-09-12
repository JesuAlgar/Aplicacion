namespace PasarelaPagos.Models
{
    public class DetallesPago
    {
        public decimal Monto { get; set; }
        public string MetodoPago { get; set; }
        public string NumeroTarjeta { get; set; }
        public string CVV { get; set; }
        public string FechaExpiracion { get; set; }
    }
}
