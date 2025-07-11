using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Web_Api_Contable.Services.SEGURIDAD;

namespace Web_Api_Contable.Controllers
{
    [ApiController]
    //[Route("[controller]/[action]")]
    //[Route("api/[controller]/[action]")]
    [Route("[controller]/[action]")]

    public class LoginController : ControllerBase
    {
        private readonly IUsuarioServices _iusuarioService;

        public LoginController(IUsuarioServices iusuarioService)
        {
            _iusuarioService = iusuarioService;
        }

        [HttpGet]
        public IActionResult ReadUser(string user)
        {
            var resultado = _iusuarioService.ReadUser(user);
            return Ok(resultado);
        }
        [HttpGet]
        public async Task<IActionResult> ValidaUsuario(string user, string password)
        {
            var resultado = await _iusuarioService.ValidaUsuario(user, password);
            return Ok(resultado);
        }
        [HttpPost]
        public async Task<IActionResult> ValidaPermiso(string user, string proceso)
        {
            var resultado = await _iusuarioService.ValidaPermiso(user, proceso);
            return Ok(resultado);
        }


    }
}
