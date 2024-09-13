using System.Net.Http;
using System.Threading.Tasks;

namespace VendedorAPI.Services
{
    public class PagosService
    {
        private readonly HttpClient _httpClient;

        public PagosService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> ProcesarPago(Tarjeta tarjeta)
        {
            var urlPasarela = "https://tu-dominio-o-ip/api/pasarela/intento-pago";
            return await _httpClient.PostAsJsonAsync(urlPasarela, tarjeta);
        }
    }
}
