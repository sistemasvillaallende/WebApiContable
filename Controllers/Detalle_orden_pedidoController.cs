using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Web_Api_Contable.Services.FOP;

namespace Web_Api_Contable.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Detalle_orden_pedidoController : Controller
    {
        private IDetalle_orden_pedidoService _Detalle_orden_pedidoService;
        public Detalle_orden_pedidoController(IDetalle_orden_pedidoService Detalle_orden_pedidoService)
        {
            _Detalle_orden_pedidoService = Detalle_orden_pedidoService;
        }
        [HttpGet]
        public IActionResult getByPk(int Nro_orden_pedido, int Nro_item)
        {
            var Detalle_orden_pedido = _Detalle_orden_pedidoService.getByPk(Nro_orden_pedido, Nro_item);
            if (Detalle_orden_pedido == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Detalle_orden_pedido);
        }

        [HttpGet]
        public IActionResult getByNro_pedido(int Nro_orden_pedido)
        {
            var Detalle_orden_pedido = _Detalle_orden_pedidoService.GetByNro_pedido(Nro_orden_pedido);
            if (Detalle_orden_pedido == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Detalle_orden_pedido);
        }
    }


}

