using Microsoft.AspNetCore.Mvc;
using Web_Api_Contable.Services.FOP;

namespace Web_Api_Contable.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Detalle_orden_compraController: Controller
    {
        private IDetalle_orden_compraService _Detalle_orden_compraService;
        public Detalle_orden_compraController(IDetalle_orden_compraService Detalle_orden_compraService)
        {
            _Detalle_orden_compraService = Detalle_orden_compraService;
        }

        [HttpGet]
        public IActionResult GetByPk(int nroOrdenCompra)
        {
            try
            {
                var resultado = _Detalle_orden_compraService.getByPk(nroOrdenCompra);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}
