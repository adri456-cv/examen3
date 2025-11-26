using examen3Contabilidad;
using System.Text.Json;

public class ContabilidadService : IContabilidadService
{
    private readonly HttpClient _http;

    public ContabilidadService(HttpClient http)
    {
        _http = http;
    }

    public async Task<decimal> ObtenerSaldoPorCI(int ci)
    {
        // 1. Obtener facturas
        var facturasJson = await _http.GetStringAsync(
            "https://programacionweb2examen3-production.up.railway.app/api/Facturas/Listar"
        );
        var facturas = JsonSerializer.Deserialize<List<FacturaDTO>>(facturasJson);

        // Prevención
        if (facturas == null) return 0;

        // Filtrar facturas del cliente
        var facturasCliente = facturas.Where(f => f.ClienteCi == ci).ToList();


        // 2. Obtener pagos
        var pagosJson = await _http.GetStringAsync(
            "https://programacionweb2examen3-production.up.railway.app/api/Pagos/Listar"
        );
        var pagos = JsonSerializer.Deserialize<List<PagoDTO>>(pagosJson);

        if (pagos == null) return 0;

        // Filtrar pagos que correspondan a las facturas del cliente
        var codigosFacturas = facturasCliente.Select(f => f.Codigo).ToList();

        var pagosCliente = pagos
            .Where(p => codigosFacturas.Contains(p.FacturaCodigo))
            .ToList();

        // 3. Totales
        decimal totalFacturas = facturasCliente.Sum(f => f.MontoTotal);
        decimal totalPagos = pagosCliente.Sum(p => p.MontoPagado);

        // 4. Saldo = Pagos - Facturas
        decimal saldo = totalPagos - totalFacturas;

        return saldo;
    }
}
