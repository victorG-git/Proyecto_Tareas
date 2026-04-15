using System;
using System.Collections.Generic;

namespace Proyecto_Tareas.Aplicacion.DTOs
{
    public class TareaDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public DateTime FechaLimite { get; set; }
        public EstadoTarea Estado { get; set; }
        public PrioridadTarea Prioridad { get; set; }
        public List<int> IdsSubtareas { get; set; } = new List<int>();

        public TareaDto()
        {
        }

        public TareaDto(
            int id,
            string titulo,
            DateTime fechaLimite,
            EstadoTarea estado,
            PrioridadTarea prioridad,
            List<int> idsSubtareas)
        {
            Id = id;
            Titulo = titulo;
            FechaLimite = fechaLimite;
            Estado = estado;
            Prioridad = prioridad;
            IdsSubtareas = idsSubtareas;
        }
    }
}