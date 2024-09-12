namespace VendedorAPI.Models
{
    public class ProductoRequest
    {
        public Cliente Cliente { get; set; }
        public DetallesPago DetallesPago { get; set; }
    }

    public class Cliente
    {
        public string Nombre { get; set; }
        public string Email { get; set; }
    }

    public class DetallesPago
    {
        public decimal Monto { get; set; }
        public string MetodoPago { get; set; }
        public string NumeroTarjeta { get; set; }
        public string CVV { get; set; }
        public string FechaExpiracion { get; set; }
    }
}
