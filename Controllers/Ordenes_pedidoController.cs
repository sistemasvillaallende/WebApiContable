using System.Data.SqlClient;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using MOTOR_WORKFLOW.Models;
using Newtonsoft.Json;
using Web_Api_Contable.Entities.FOP;
using Web_Api_Contable.Models;
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
        [HttpPost]
        public IActionResult insert([FromBody] OrdenPedidoRequest request)
        {
            try
            {
                this._Ordenes_pedidoService.insert(request.Orden, request.DetalleItems,request.Auditoria);
                return Ok(new { message = "Orden de pedido insertada correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
        [HttpPost]
        public IActionResult Update(int nroOrdenPedido, [FromBody] OrdenPedidoRequest request)
        {
            try
            {
                _Ordenes_pedidoService.update(nroOrdenPedido, request);
                return Ok(new { message = "Orden de pedido modificada correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult Delete(int nroOrdenPedido)
        {
            try
            {
                _Ordenes_pedidoService.delete(nroOrdenPedido);
                return Ok(new { message = "Orden de pedido eliminada correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult Anular(int nroOrdenPedido, [FromBody] Auditoria auditoria)
        {
            try
            {
                _Ordenes_pedidoService.anular(nroOrdenPedido, auditoria);
                return Ok(new { message = "Orden de pedido anulada correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }




    }
}

