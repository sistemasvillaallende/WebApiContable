using Microsoft.AspNetCore.Mvc;
using Web_Api_Contable.Services.FOP;

namespace Web_Api_Contable.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProgramasController: Controller
    {
        private readonly IProgramasService _programaService;

        public ProgramasController(IProgramasService programaService)
        {
            _programaService = programaService;
        }

        [HttpGet]
        public IActionResult GetListProgramas(int id_secretaria,int id_direccion)
        {
            try
            {
                var programas= _programaService.getListProgramas(id_secretaria,id_direccion);
                return Ok(programas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetListProgramasById(int id_programa)
        {
            try
            {
                var programas = _programaService.getListProgramasById(id_programa);
                return Ok(programas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}
