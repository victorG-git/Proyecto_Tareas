using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;
using Proyecto_Tareas.Dominio.Clases;

namespace Proyecto_Tareas.Infraestructura.Repositorios
{
    public class RepositorioTareasSql
    {
        public void Agregar(Tarea tarea)
        {
        }

        public List<Tarea> ObtenerTodas()
        {
            return new List<Tarea>();
        }

        public Tarea? BuscarPorId(int id)
        {
            return null;
        }

        public bool Eliminar(int id)
        {
            return false;
        }

        public void GuardarCambios()
        {
        }
    }
}