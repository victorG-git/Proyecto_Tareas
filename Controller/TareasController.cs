using Microsoft.AspNetCore.Mvc;

namespace Proyecto_Tareas.Controller
{

    [ApiController]
    [Route("api/[controller]")]
    public class TareasController : ControllerBase
    {
        [HttpGet] // GET /api/tareas
        public IActionResult GetAll() { }

        [HttpGet("{id}")] // GET /api/tareas/1
        public IActionResult GetById(int id) { }

        [HttpPost] // POST /api/tareas
        public IActionResult Create() { }

        [HttpPut("{id}")] // PUT /api/tareas/1
        public IActionResult Update(int id, ) { }

        [HttpDelete("{id}")] // DELETE /api/tareas/1
        public IActionResult Delete(int id) { }
    }