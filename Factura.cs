namespace examen3Contabilidad
{
    public class Factura
    {
        private readonly HttpClient _http;

        public Factura(HttpClient http)
        {
            _http = http;
        }

        public async Task<FacturaDTO?> ObtenerFactura(int facturaCodigo)
        {
            return await _http.GetFromJsonAsync<FacturaDTO>($"api/facturas/{facturaCodigo}");
        }
    }
}
