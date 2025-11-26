using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace examen3Contabilidad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContabilidadController : ControllerBase
    {
        private readonly IContabilidadService _service;

        public ContabilidadController(IContabilidadService service)
        {
            _service = service;
        }

        [HttpGet("Saldo/{ci}")]
        public async Task<IActionResult> ObtenerSaldo(int ci)
        {
            var saldo = await _service.ObtenerSaldoPorCI(ci);
            return Ok(new { CI = ci, Saldo = saldo });
        }
    }
}
