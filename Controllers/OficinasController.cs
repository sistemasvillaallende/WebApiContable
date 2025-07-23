using Microsoft.AspNetCore.Mvc;
using Web_Api_Contable.Services.FOP;

namespace Web_Api_Contable.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OficinasController: Controller
    {
        private readonly IOficinaService _programaService;

        public OficinasController(IOficinaService oficinaService)
        {
            _programaService = oficinaService;
        }

        [HttpGet]
        public IActionResult GetListOficinas(int id_oficina)
        {
            try
            {
                var oficinas = _programaService.getListOficinas(id_oficina);
                return Ok(oficinas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}
