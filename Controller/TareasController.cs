using Microsoft.AspNetCore.Mvc;
using Proyecto_Tareas.Dominio.Clases;

namespace Proyecto_Tareas.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class TareasController : ControllerBase
    {
        private static readonly List<Tarea> _tareas = new();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_tareas);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var tarea = _tareas.FirstOrDefault(t => t.Id == id);

            if (tarea == null)
                return NotFound();

            return Ok(tarea);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Tarea nuevaTarea)
        {
            try
            {
                if (_tareas.Any(t => t.Id == nuevaTarea.Id))
                    return BadRequest("Ya existe una tarea con ese ID");

                _tareas.Add(nuevaTarea);

                return CreatedAtAction(nameof(GetById), new { id = nuevaTarea.Id }, nuevaTarea);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Tarea tareaActualizada)
        {
            var tarea = _tareas.FirstOrDefault(t => t.Id == id);

            if (tarea == null)
                return NotFound();

            try
            {
                _tareas.Remove(tarea);
                _tareas.Add(tareaActualizada);

                return Ok(tareaActualizada);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var tarea = _tareas.FirstOrDefault(t => t.Id == id);

            if (tarea == null)
                return NotFound();

            _tareas.Remove(tarea);

            return NoContent();
        }
    }
}