using Microsoft.AspNetCore.Mvc;
using Web_Api_Tramitescatastro.Entities;
using Web_Api_Tramitescatastro.Services;

namespace Web_Api_Tramitescatastro.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TiposTramitesController : ControllerBase
    {
        private readonly ITiposTramitesServices _itipostramitesService;
     

        public TiposTramitesController(ITiposTramitesServices tipostramitesServices)
        {
            _itipostramitesService = tipostramitesServices;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public IActionResult read()
        {
            var tipostramites = _itipostramitesService.read();

            return Ok(tipostramites);
        }

        [HttpGet]
        public IActionResult getByPk(int id)
        { 
            var tipostramites = _itipostramitesService.getByPk(id);
            return Ok(tipostramites);
        }
        
    }
}
