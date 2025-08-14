using Microsoft.AspNetCore.Mvc;
using Web_Api_Contable.Models;
using Web_Api_Contable.Services.FOP;

namespace Web_Api_Contable.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Ordenes_CompraController : Controller
    {
        private IOrdenesCompraService _Ordenes_compraService;
        public Ordenes_CompraController(IOrdenesCompraService Ordenes_CompraService)
        {
            _Ordenes_compraService = Ordenes_CompraService;
        }

        [HttpGet]
        public IActionResult GetByPk(int nroOrdenCompra)
        {
            try
            {
                var resultado = _Ordenes_compraService.getByPk(nroOrdenCompra);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult insert([FromBody] OrdenCompraRequest request)
        {
            try
            {
                this._Ordenes_compraService.insert(request.Orden, request.DetalleItems, request.Auditoria);
                return Ok(new { message = "Orden de compra insertada correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
        [HttpPost]
        public IActionResult Update(int nroOrdenCompra ,[FromBody] OrdenCompraRequest request)
        {
            try
            {
               _Ordenes_compraService.update(nroOrdenCompra, request);
                return Ok(new { message = "Orden de compra modificada correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

    }
}
