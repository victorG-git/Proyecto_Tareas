using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Proyecto_Tareas.Aplicacion.DTOs;

namespace Proyecto_Tareas.Infraestructura.Repositorios
{
    public class TareaRepositorio
    {
        public void Guardar(string ruta, List<TareaDto> tareas)
        {
            var opciones = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(tareas, opciones);
            File.WriteAllText(ruta, json);
        }

        public List<TareaDto> Cargar(string ruta)
        {
            if (!File.Exists(ruta))
                return new List<TareaDto>();

            string json = File.ReadAllText(ruta);

            return JsonSerializer.Deserialize<List<TareaDto>>(json)
                   ?? new List<TareaDto>();
        }
    }
}