namespace examen3Contabilidad
{
    public class Pago
    {

        private readonly HttpClient _http;

        public Pago(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<PagoDTO>> ObtenerPagos(int facturaCodigo)
        {
            var response = await _http.GetFromJsonAsync<List<PagoDTO>>(
                $"api/Pagos/ListarPorFactura/{facturaCodigo}"
            );

            return response ?? new List<PagoDTO>();
        }
    }
}
