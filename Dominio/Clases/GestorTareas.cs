using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Proyecto_Tareas.Aplicacion.DTOs;
using Proyecto_Tareas.Infraestructura.Repositorios;

namespace Proyecto_Tareas.Dominio.Clases
{
    public class GestorTareas
    {
        private readonly List<Tarea> tareas;
        private readonly Dictionary<int, Tarea> identificador;

        // Repositorio JSON antiguo
        // private readonly TareaRepositorio repositorio;
        // private readonly string rutaArchivo;

        // Repositorio SQL nuevo
        private readonly RepositorioTareasSql repositorioSQL;


        public GestorTareas()
        {
            tareas = new List<Tarea>();
            identificador = new Dictionary<int, Tarea>();
            
            //repositorio = new TareaRepositorio();
            //rutaArchivo = "tareas.json";

            repositorioSQL = new RepositorioTareasSql();
        }

        public void AgregarTarea(Tarea tarea)
        {
            ArgumentNullException.ThrowIfNull(tarea);

            if (!identificador.TryAdd(tarea.Id, tarea))
                throw new ArgumentException($"Ya existe una tarea con id {tarea.Id}.");

            tareas.Add(tarea);

            // repositorio.Agregar(tarea);
            // repositorio.GuardarCambios();
        }

        public List<Tarea> ObtenerTareas()
        {
            return new List<Tarea>(tareas);
        }

        public Tarea? BuscarPorId(int id)
        {
            return identificador.TryGetValue(id, out Tarea? tarea) ? tarea : null;

            // return repositorio.BuscarPorId(id);
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

            // repositorio.Eliminar(id);
            // repositorio.GuardarCambios();

            return true;
        }

        public void GuardarDatos()
        {
            /*
            List<TareaDto> tareasDto = tareas
                .Select(t => t.ToDto())
                .ToList();

            repositorio.Guardar(rutaArchivo, tareasDto);
            */

            // repositorioSQL.GuardarCambios();
        }

        public void CargarDatos()
        {
            /*
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
            */

            // SQL nuevo
            /*
            List<Tarea> tareasBaseDatos = repositorioSQL.ObtenerTodas();

            tareas.Clear();
            identificador.Clear();

            foreach (Tarea tarea in tareasBaseDatos)
            {
                tareas.Add(tarea);
                identificador.Add(tarea.Id, tarea);
            }
            */
        }
    }
}