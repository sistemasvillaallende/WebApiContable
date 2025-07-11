using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Web_Api_Contable.Services.FOP;

namespace Web_Api_Contable.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProveedoresController : Controller
    {
        private IProveedoresService _ProveedoresService;
        public ProveedoresController(IProveedoresService ProveedoresService)
        {
            _ProveedoresService = ProveedoresService;
        }
        [HttpGet]
        public IActionResult getByPk(int cod_proveedor)
        {
            var Proveedores = _ProveedoresService.getByPk(cod_proveedor);
            if (Proveedores == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Proveedores);
        }







    }
}

