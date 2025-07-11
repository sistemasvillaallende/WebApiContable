using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Web_Api_Contable.Services.FOP;

namespace Web_Api_Contable.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Ordenes_pedidoController : Controller
    {
        private IOrdenes_pedidoService _Ordenes_pedidoService;
        public Ordenes_pedidoController(IOrdenes_pedidoService Ordenes_pedidoService)
        {
            _Ordenes_pedidoService = Ordenes_pedidoService;
        }

        [HttpGet]
        public IActionResult getByPk(int Nro_orden_pedido)
        {
            var Ordenes_pedido = _Ordenes_pedidoService.getByPk(Nro_orden_pedido);
            if (Ordenes_pedido == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Ordenes_pedido);
        }
        [HttpGet]
        public IActionResult readOrdenesByProveedor(int codigo)
        {
            var Ordenes_pedido = _Ordenes_pedidoService.readOrdenesByProveedor(codigo);
            return Ok(Ordenes_pedido);
        }
        [HttpGet]
        public IActionResult readOrdenesByCuit(string cuit)
        {
            var Ordenes_pedido = _Ordenes_pedidoService.readOrdenesByCuit(cuit);
            return Ok(Ordenes_pedido);
        }
    }
}

