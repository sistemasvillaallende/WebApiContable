using Microsoft.AspNetCore.Mvc;
using Web_Api_Tramitescatastro.Entities;
using Web_Api_Tramitescatastro.Services;

namespace Web_Api_Tramitescatastro.Controllers
{
    
    [ApiController]
    //[Route("[controller]/[action]")]
    [Route("api/[controller]/[action]")]
    public class Adjuntos_x_TramitesController : Controller
    {

        private readonly IAdjuntos_x_TramitesServices _iadjuntos_x_tramitesService;

        public Adjuntos_x_TramitesController(IAdjuntos_x_TramitesServices adjuntos_x_tramitesService)
        {
            _iadjuntos_x_tramitesService = adjuntos_x_tramitesService;
        }
        [HttpGet]
        public IActionResult read()
        {
            var adjuntostramites = _iadjuntos_x_tramitesService.read();
            return Ok(adjuntostramites);
        }
        [HttpPost]
        public IActionResult insert(Entities.ADJUNTOS_X_TRAMITES obj)
        {
            var adjuntostramites = _iadjuntos_x_tramitesService.insert(obj);
            return Ok(adjuntostramites);
        }
        [HttpPost]
        public IActionResult update(Entities.ADJUNTOS_X_TRAMITES obj)
        {
            _iadjuntos_x_tramitesService.update(obj);
            var adjuntostramites = _iadjuntos_x_tramitesService.read();
            return Ok(adjuntostramites);
        }
        [HttpPost]
        public IActionResult delete(Entities.ADJUNTOS_X_TRAMITES obj)
        {
            _iadjuntos_x_tramitesService.delete(obj);
            var adjuntostramites = _iadjuntos_x_tramitesService.read();
            return Ok(adjuntostramites);
        }
        [HttpGet]
        public IActionResult getByPk(int nro_bad)
        {
            var adjuntostramites = _iadjuntos_x_tramitesService.getByPk(nro_bad);
            return Ok(adjuntostramites);
        }
    }
}
