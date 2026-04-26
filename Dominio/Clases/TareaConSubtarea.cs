using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Tareas.Dominio.Clases
{
    internal class TareaConSubtarea : Tarea
    {
            public TareaConSubtarea(int id, string titulo, string descripcion, DateTime fechaLimite, PrioridadTarea prioridad)
           : base(id, titulo, descripcion, fechaLimite, prioridad)
            {
            }
    }
}
