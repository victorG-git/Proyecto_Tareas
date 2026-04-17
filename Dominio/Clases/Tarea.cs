using System;
using System.Collections.Generic;
using System.Linq;
using Proyecto_Tareas.Aplicacion.DTOs;

namespace Proyecto_Tareas.Dominio.Clases
{
    public class Tarea
    {
        private readonly List<Tarea> _subtareas = new();

        public int Id { get; private set; }
        public string Titulo { get; private set; }
        public string Descripcion { get; private set; }
        public DateTime FechaCreacion { get; private set; }
        public DateTime? FechaFinalizacion { get; private set; }
        public DateTime FechaLimite { get; private set; }
        public EstadoTarea Estado { get; private set; }
        public PrioridadTarea Prioridad { get; private set; }

        public IReadOnlyCollection<Tarea> Subtareas => _subtareas.AsReadOnly();

        public Tarea(int id, string titulo, string? descripcion, DateTime fechaLimite, PrioridadTarea prioridad)
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

            FechaCreacion = DateTime.Now;
            FechaFinalizacion = null;
            FechaLimite = fechaLimite;
            Estado = EstadoTarea.Pendiente;
            Prioridad = prioridad;
        }

        private Tarea(int id, string titulo, DateTime fechaLimite, EstadoTarea estado, PrioridadTarea prioridad)
        {
            Id = id;
            Titulo = titulo;
            Descripcion = "Descripcion no recuperada desde JSON";
            FechaCreacion = DateTime.Now;
            FechaFinalizacion = estado == EstadoTarea.Completado ? DateTime.Now : null;
            FechaLimite = fechaLimite;
            Estado = estado;
            Prioridad = prioridad;
        }

        public static Tarea FromDto(TareaDto dto)
        {
            ArgumentNullException.ThrowIfNull(dto);

            return new Tarea(
                dto.Id,
                dto.Titulo,
                dto.FechaLimite,
                dto.Estado,
                dto.Prioridad
            );
        }

        public TareaDto ToDto()
        {
            return new TareaDto(
                Id,
                Titulo,
                FechaLimite,
                Estado,
                Prioridad,
                _subtareas.Select(s => s.Id).ToList()
            );
        }

        public void Iniciar()
        {
            if (Estado != EstadoTarea.Pendiente)
                throw new InvalidOperationException("Solo se puede iniciar una tarea pendiente");

            Estado = EstadoTarea.EnProgreso;
        }

        public void Finalizar()
        {
            if (Estado == EstadoTarea.Cancelado)
                throw new InvalidOperationException("No se puede finalizar una tarea cancelada");

            if (Estado == EstadoTarea.Completado)
                throw new InvalidOperationException("La tarea ya esta completada");

            Estado = EstadoTarea.Completado;
            FechaFinalizacion = DateTime.Now;
        }

        public void Cancelar()
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

        public string ObtenerResumen()
        {
            return $"[{Id}] {Titulo} | Estado: {Estado} | Prioridad: {Prioridad} | Fecha limite: {FechaLimite:g}";
        }

        public string ObtenerDetalle()
        {
            string fechaFinalizacionTexto = FechaFinalizacion.HasValue
                ? FechaFinalizacion.Value.ToString("g")
                : "Sin finalizar";

            return $"Id: {Id} | Titulo: {Titulo} | Descripcion: {Descripcion} | " +
                   $"Fecha creacion: {FechaCreacion:g} | Fecha finalizacion: {fechaFinalizacionTexto} | " +
                   $"Fecha limite: {FechaLimite:g} | Estado: {Estado} | Prioridad: {Prioridad} | " +
                   $"Numero de subtareas: {_subtareas.Count}";
        }
    }
}