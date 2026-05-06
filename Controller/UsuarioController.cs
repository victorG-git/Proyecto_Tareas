using Microsoft.AspNetCore.Mvc;

namespace Proyecto_Tareas.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private static readonly List<string> _usuarios = new()
        {
            "Juan",
            "Ana"
        };

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_usuarios);
        }
    }
}