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
        public DateTime ProximaFecha { get; private set; } = DateTime.Now;
        

        public TareaProgramada(int id, string titulo, string descripcion, DateTime fechaLimite,
                                  PrioridadTarea prioridad, int frecuenciaDias)
               : base(id, titulo, descripcion, fechaLimite, prioridad)
        {
            if (frecuenciaDias <= 0)
                throw new ArgumentException("Frecuencia invalida");

            FrecuenciaDias = frecuenciaDias;
            ProximaFecha = fechaLimite.AddDays(frecuenciaDias);
        }

        public void FinalziarTarea()
        {
            if (Estado == EstadoTarea.Cancelado)
                throw new InvalidOperationException("No se puede finalizar una tarea cancelada");

            if (Estado == EstadoTarea.Completado)
                throw new InvalidOperationException("La tarea ya esta completada");

            Estado = EstadoTarea.Completado;
            fechaFinalizacion = DateTime.Now;
        }

        public void GenerarSiguienteFecha()
        {

        }

        public override string ObtenerResumen()
        {
            return $"[{Id}] {Titulo} | Estado: {Estado} | Prioridad: {Prioridad} | Fecha limite: {fechaLimite:g}";
        }

        public string ObtenerDetalles()
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
