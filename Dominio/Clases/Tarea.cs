using System;
using System.Collections.Generic;
using System.Linq;
using Proyecto_Tareas.Aplicacion.DTOs;

namespace Proyecto_Tareas.Dominio.Clases
{
    public class Tarea
    {
        private readonly List<Tarea> _subtareas = new();

        public int Id { get; protected set; }
        public string Titulo { get; protected set; }
        public string Descripcion { get; protected set; }
        public DateTime fechaCreacion { get; protected set; }
        public DateTime? fechaFinalizacion { get; protected set; }
        public DateTime fechaLimite { get; protected set; }
        public EstadoTarea Estado { get; protected set; }
        public PrioridadTarea Prioridad { get; protected set; }

        public IReadOnlyCollection<Tarea> Subtareas => _subtareas.AsReadOnly();

        public Tarea(int id, string titulo, string descripcion, DateTime fechaLimite, PrioridadTarea prioridad)
        {
            if (id <= 0)
                throw new ArgumentException("El id debe ser mayor que 0");

            if (string.IsNullOrWhiteSpace(titulo))
                throw new ArgumentException("El titulo no puede estar vacio");

            if (fechaLimite <= DateTime.Now)
                throw new ArgumentException("La fecha limite tiene que ser posterior al momento actual");

            Id = id;
            Titulo = titulo;

            if (descripcion == null)
                Descripcion = "";
            else
                Descripcion = descripcion;

            fechaCreacion = DateTime.Now;
            fechaFinalizacion = null;
            fechaLimite = fechaLimite;
            Estado = EstadoTarea.Pendiente;
            Prioridad = prioridad;
        }

        private Tarea(int id, string titulo, DateTime fechaLimite, EstadoTarea estado, PrioridadTarea prioridad)
        {
            Id = id;
            Titulo = titulo;
            Descripcion = "Descripcion no recuperada desde JSON";
            fechaCreacion = DateTime.Now;
            fechaFinalizacion = estado == EstadoTarea.Completado ? DateTime.Now : null;
            fechaLimite = fechaLimite;
            Estado = estado;
            Prioridad = prioridad;
        }

        //Arreglos DTO

        /*
        public static Tarea FromDto(TareaDto dto)
        {

            ArgumentNullException.ThrowIfNull(dto);

            return new Tarea(
                dto.Id,
                dto.Titulo,
                dto.fechaLimite,
                dto.Estado,
                dto.Prioridad
            );
        }

        public TareaDto ToDto()
        {
            return new TareaDto(
                Id,
                Titulo,
                fechaLimite,
                Estado,
                Prioridad,
                _subtareas.Select(s => s.Id).ToList()
            );
        }
        */

        public virtual void Iniciar()
        {
            if (Estado != EstadoTarea.Pendiente)
                throw new InvalidOperationException("Solo se puede iniciar una tarea pendiente");

            Estado = EstadoTarea.EnProgreso;
        }

        public virtual void Finalizar()
        {
            if (Estado == EstadoTarea.Cancelado)
                throw new InvalidOperationException("No se puede finalizar una tarea cancelada");

            if (Estado == EstadoTarea.Completado)
                throw new InvalidOperationException("La tarea ya esta completada");

            Estado = EstadoTarea.Completado;
            fechaFinalizacion = DateTime.Now;
        }

        public virtual void Cancelar()
        {
            if (Estado == EstadoTarea.Completado)
                throw new InvalidOperationException("No se puede cancelar una tarea completada");

            if (Estado == EstadoTarea.Cancelado)
                throw new InvalidOperationException("La tarea ya esta cancelada");

            Estado = EstadoTarea.Cancelado;
        }

        public void AgregarSubtarea(Tarea subtarea)
        {
            ArgumentNullException.ThrowIfNull(subtarea);

            if (subtarea.Id == Id)
                throw new InvalidOperationException("Una tarea no puede agregarse a si misma como subtarea");

            if (_subtareas.Any(t => t.Id == subtarea.Id))
                throw new InvalidOperationException("Ya existe una subtarea con ese id");

            _subtareas.Add(subtarea);
        }

        public void EliminarSubtarea(int idSubtarea)
        {
            Tarea? subtarea = _subtareas.FirstOrDefault(t => t.Id == idSubtarea);

            if (subtarea is null)
                throw new InvalidOperationException("No existe una subtarea con ese id");

            _subtareas.Remove(subtarea);
        }

        public virtual string ObtenerResumen()
        {
            return $"[{Id}] {Titulo} | Estado: {Estado} | Prioridad: {Prioridad} | Fecha limite: {fechaLimite:g}";
        }

        public virtual string ObtenerDetalle()
        {
            string fechaTexto;

            if (fechaFinalizacion.HasValue)
                fechaTexto = fechaFinalizacion.Value.ToString("g");
            else
                fechaTexto = "Sin finalizar";

            return $"Id: {Id} | Titulo: {Titulo} | Descripcion: {Descripcion} | " +
                   $"Fecha creacion: {fechaCreacion:g} | Fecha finalizacion: {fechaTexto} | " +
                   $"Fecha limite: {fechaLimite:g} | Estado: {Estado} | Prioridad: {Prioridad} | " +
                   $"Numero de subtareas: {_subtareas.Count}";
        }
    }
}