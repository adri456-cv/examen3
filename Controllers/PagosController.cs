using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace examen3Contabilidad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagosController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        public PagosController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        [HttpGet("Productos")]
        public async Task<IActionResult> GetPedidosCliente()
        {
            string URL = "https://programacionweb2examen3-production.up.railway.app/api/Pagos/Listar";
            HttpResponseMessage respuesta = await _httpClient.GetAsync(URL);

            if (!respuesta.IsSuccessStatusCode)
            {

                return StatusCode((int)respuesta.StatusCode,
                                  $"Error al obtener los datos del microservicio Pagos: {respuesta.ReasonPhrase}");
            }
            string jsonRespuesta = await respuesta.Content.ReadAsStringAsync();
            JsonElement datos = JsonSerializer.Deserialize<JsonElement>(jsonRespuesta);
            return Ok(datos);
        }
    }
}
