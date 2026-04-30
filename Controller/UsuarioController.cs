using Microsoft.AspNetCore.Mvc;

namespace Proyecto_Tareas.Controller
{

    [ApiController]
    [Route("api/controller")]
    public class UsuarioController : ControllerBase
    {
        /*
        private readonly GestorTareasService _servicio;

        public UsuarioController(GestorTareasService servicio)
         => _servicio = servicio;

        [HttpGet]
        public IActionResult GetAll() { }

        [HttpGet("{id}/tareas")]
        public IActionResult GetTareas(int id)
        {
            var tareas = _servicio.ObtenerTareasPorUsuario(id);
            if (tareas == null) return NotFound();
            return Ok(tareas);
        }*/
    }
}
