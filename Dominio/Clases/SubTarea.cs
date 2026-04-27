using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Tareas.Dominio.Clases
{
    internal class SubTarea : Tarea
    {
        private readonly List<Tarea> tareas;
        private int IdSubTarea { get; set; }

        private DateTime FehchaCreacionSubtareaINterna { get; set; }

        public SubTarea(int id, string titulo, string? descripcion, DateTime fechaLimite, PrioridadTarea prioridad, int IdSubTarea, DateTime FehchaCreacionSubtareaINterna)
        {

        }
    }
}
