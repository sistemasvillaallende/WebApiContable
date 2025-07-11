using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Newtonsoft.Json;
using Web_Api_Contable.Services.SM;

namespace Web_Api_Contable.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SM_Solicitud_materialController : Controller
    {
        private ISM_Solicitud_materialService _SM_Solicitud_materialService;
        public SM_Solicitud_materialController(ISM_Solicitud_materialService SM_Solicitud_materialService)
        {
            _SM_Solicitud_materialService = SM_Solicitud_materialService;
        }

        //[HttpGet]
        //public IActionResult getByPk(int id)
        //{
        //    var Sm_solicitud_material = _SM_Solicitud_materialService.getByPk(id);
        //    if (Sm_solicitud_material == null)
        //    {
        //        return BadRequest(new { message = "Error al obtener los datos" });
        //    }
        //    return Ok(Sm_solicitud_material);
        //}

        [HttpGet]
        public IActionResult Tipos_solicitud()
        {
            var Tiposolicitud = _SM_Solicitud_materialService.Tipo_solicitud();
            if (Tiposolicitud == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Tiposolicitud);
        }

        [HttpGet]
        public IActionResult Prioridad()
        {
            var Prioridades = _SM_Solicitud_materialService.Prioridad();
            if (Prioridades == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Prioridades);
        }

        [HttpGet]
        public IActionResult Estado_solicitud()
        {
            var Estadosolicitud = _SM_Solicitud_materialService.Estado_solicitud();
            if (Estadosolicitud == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Estadosolicitud);
        }




    }
}

