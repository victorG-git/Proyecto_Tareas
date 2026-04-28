using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Tareas.Dominio.Clases
{
    internal class TareaConSubtarea : Tarea
    {

            public int FrecuenciaDias;
            public DateTime ProximaFecha;
            
            
            public TareaConSubtarea(int id, string titulo, string descripcion, DateTime fechaLimite, PrioridadTarea prioridad)
           : base(id, titulo, descripcion, fechaLimite, prioridad)
            {
            }

            public override void Finalizar()
            {
                if (Estado == EstadoTarea.Cancelado)
                    throw new InvalidOperationException("No se puede finalizar una tarea cancelada");

                if (Estado == EstadoTarea.Completado)
                    throw new InvalidOperationException("La tarea ya esta completada");

                Estado = EstadoTarea.Completado;
                fechaFinalizacion = DateTime.Now;
        }

            public override string ObtenerResumen()
            {
            string fechaTexto;

            if (fechaFinalizacion.HasValue)
                fechaTexto = fechaFinalizacion.Value.ToString("g");
            else
                fechaTexto = "Sin finalizar";

            return $"Id: {Id} | Titulo: {Titulo} | Descripcion: {Descripcion} | " +
                   $"Fecha creacion: {fechaCreacion:g} | Fecha finalizacion: {fechaTexto} | " +
                   $"Fecha limite: {fechaLimite:g} | Estado: {Estado} | Prioridad: {Prioridad} | ";

        }
    }  

}
