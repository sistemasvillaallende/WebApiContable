using Microsoft.AspNetCore.Mvc;
using Web_Api_Contable.Services.FOP;

namespace Web_Api_Contable.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SecretariaController : Controller
    {
        private readonly ISecretariasService _secretariaService;

        public SecretariaController(ISecretariasService secretariaService)
        {
            _secretariaService = secretariaService;
        }

        [HttpGet]
        public IActionResult GetListSecretarias(int id_secretaria)
        {
            try
            {
               var secretarias = _secretariaService.getListSecretarias(id_secretaria);
                return Ok(secretarias);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetSecretariasByNombre(int ejercicio, string nombre)
        {
            try
            {
                var result = _secretariaService.getSecretariasByNombre(ejercicio, nombre);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }


    }
}
