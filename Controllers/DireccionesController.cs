using Microsoft.AspNetCore.Mvc;
using Web_Api_Contable.Services.FOP;

namespace Web_Api_Contable.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DireccionesController :Controller
    {

        private readonly IDireccionService _direccionService;

        public DireccionesController(IDireccionService direccionService)
        {
            _direccionService = direccionService;
        }

        [HttpGet]
        public IActionResult GetListDirecciones(int id_secretaria)
        {
            try
            {
                var direcciones = _direccionService.getListDirecciones(id_secretaria);
                return Ok(direcciones);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetDireccionesByNombre(int ejercicio, string nombre)
        {
            try
            {
                var direcciones = _direccionService.getDireccionesByNombre(ejercicio, nombre);
                return Ok(direcciones);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}
