using System;
using System.Collections.Generic;
using System.Linq;
using Proyecto_Tareas.Aplicacion.DTOs;
using Proyecto_Tareas.Infraestructura.Repositorios;

namespace Proyecto_Tareas.Dominio.Clases
{
    public class GestorTareas
    {
        private readonly List<Tarea> tareas;
        private readonly Dictionary<int, Tarea> identificador;
        private readonly TareaRepositorio repositorio;
        private readonly string rutaArchivo;

        public GestorTareas()
        {
            tareas = new List<Tarea>();
            identificador = new Dictionary<int, Tarea>();
            repositorio = new TareaRepositorio();
            rutaArchivo = "tareas.json";
        }

        public void AgregarTarea(Tarea tarea)
        {
            ArgumentNullException.ThrowIfNull(tarea);

            if (!identificador.TryAdd(tarea.Id, tarea))
                throw new ArgumentException($"Ya existe una tarea con id {tarea.Id}.");

            tareas.Add(tarea);
        }

        public List<Tarea> ObtenerTareas()
        {
            return new List<Tarea>(tareas);
        }

        public Tarea? BuscarPorId(int id)
        {
            return identificador.TryGetValue(id, out Tarea? tarea) ? tarea : null;
        }

        public bool EliminarTarea(int id)
        {
            if (!identificador.Remove(id, out Tarea? tarea))
                return false;

            tareas.Remove(tarea);

            foreach (Tarea tareaActual in tareas)
            {
                if (tareaActual.Subtareas.Any(s => s.Id == id))
                {
                    tareaActual.EliminarSubtarea(id);
                }
            }

            return true;
        }

        public void GuardarDatos()
        {
            List<TareaDto> tareasDto = tareas
                .Select(t => t.ToDto())
                .ToList();

            repositorio.Guardar(rutaArchivo, tareasDto);
        }

        public void CargarDatos()
        {
            List<TareaDto> tareasDto = repositorio.Cargar(rutaArchivo);

            tareas.Clear();
            identificador.Clear();

            foreach (TareaDto dto in tareasDto)
            {
                Tarea tarea = Tarea.FromDto(dto);
                tareas.Add(tarea);
                identificador.Add(tarea.Id, tarea);
            }

            foreach (TareaDto dto in tareasDto)
            {
                if (!identificador.TryGetValue(dto.Id, out Tarea? tareaPadre))
                    continue;

                foreach (int idSubtarea in dto.IdsSubtareas)
                {
                    if (identificador.TryGetValue(idSubtarea, out Tarea? subtarea))
                    {
                        if (!tareaPadre.Subtareas.Any(s => s.Id == subtarea.Id))
                        {
                            tareaPadre.AgregarSubtarea(subtarea);
                        }
                    }
                }
            }
        }
    }
}