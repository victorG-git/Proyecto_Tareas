using Proyecto_Tareas.Aplicacion.DTOs;
using Proyecto_Tareas.Infraestructura.Repositorios;

namespace Proyecto_Tareas.Aplicacion.Servicio
{
    public class GestorServicio
    {
        private readonly RepositorioTareasSql repositorio;

        public GestorServicio(RepositorioTareasSql repositorio)
        {
            this.repositorio = repositorio;
        }

        public List<TareaDto> ObtenerTodas()
        {
            return repositorio.ObtenerTodas()
                .Select(t => new TareaDto
                {
                    Id = t.Id,
                    Titulo = t.Titulo,
                    FechaLimite = t.fechaLimite,
                    Estado = t.Estado,
                    Prioridad = t.Prioridad,
                    NombreUsuario = t.Usuario?.Nombre ?? "Sin asignar",
                    IdsSubtareas = t.Subtareas?.Select(s => s.Id).ToList() ?? new List<int>()
                })
                .ToList();
        }

        public TareaDto? ObtenerPorId(int id)
        {
            var tarea = repositorio.BuscarPorId(id);
            if (tarea == null) return null;

            return new TareaDto
            {
                Id = tarea.Id,
                Titulo = tarea.Titulo,
                FechaLimite = tarea.fechaLimite,
                Estado = tarea.Estado,
                Prioridad = tarea.Prioridad,
                NombreUsuario = tarea.Usuario?.Nombre ?? "Sin asignar",
                IdsSubtareas = tarea.Subtareas?.Select(s => s.Id).ToList() ?? new List<int>()
            };
        }
    }
}