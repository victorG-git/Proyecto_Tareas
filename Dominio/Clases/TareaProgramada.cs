using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Tareas.Dominio.Clases
{
    internal class TareaProgramada : Tarea
    {
        public int FrecuenciaDias { get; private set; }
        public DateTime ProximaFecha { get; private set; }


        public TareaProgramada(int id, string titulo, string descripcion, DateTime fechaLimite,
                                  PrioridadTarea prioridad, int frecuenciaDias)
               : base(id, titulo, descripcion, fechaLimite, prioridad)
        {
            if (frecuenciaDias <= 0)
                throw new ArgumentException("Frecuencia invalida");

            FrecuenciaDias = frecuenciaDias;
            ProximaFecha = fechaLimite.AddDays(frecuenciaDias);
        }
    }
}
