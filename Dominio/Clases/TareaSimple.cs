using System;

namespace Proyecto_Tareas.Dominio.Clases
{
    public class TareaSimple : Tarea
    {
        public TareaSimple(int id, string titulo, string descripcion, DateTime fechaLimite, PrioridadTarea prioridad)
            : base(id, titulo, descripcion, fechaLimite, prioridad)
        {
        }
    }
}