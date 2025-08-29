using Microsoft.AspNetCore.Mvc;
using Web_Api_Contable.Models;
using Web_Api_Contable.Services.FOP;

namespace Web_Api_Contable.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Ordenes_PagoController : Controller
    {
        private IOrdenes_pagoService _Ordenes_pagoService;
        public Ordenes_PagoController(IOrdenes_pagoService Ordenes_pagoService)
        {
            _Ordenes_pagoService = Ordenes_pagoService;
        }

        [HttpPost]
        public IActionResult insert([FromBody] OrdenPagoRequest request)
        {
            try
            {
                this._Ordenes_pagoService.insert(request);
                return Ok(new { message = "Orden de pedido insertada correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
        [HttpPost]
        public IActionResult Delete(int nroOrdenPago, Auditoria request)
        {
            try
            {
                _Ordenes_pagoService.delete(nroOrdenPago, request);
                return Ok(new { message = "Orden de pago eliminada correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }


    }
}
