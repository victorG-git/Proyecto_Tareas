using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Tareas.Dominio.Clases
{
    internal class Usuario
    { 
        public int Id { get; protected set; }
        public string Nombre { get; protected set; }
        public string Email { get; protected set; }
        public string Contrasenia { get; protected set; }
        public bool EsAdmin { get; protected set; }
        public DateTime FechaCreacion { get; protected set; }


        public Usuario (int id, string nombre, string email, string contrasenia, bool esAdmin, DateTime fechaCreacion)
        {
            Id = id;
            Nombre = nombre;
            Email = email;
            Contrasenia = contrasenia;
            EsAdmin = esAdmin;
            FechaCreacion = fechaCreacion;
        }

        public string ObtenerUsuario()
        {
            return $"[{Id}] {Nombre} | Email: {Email} | Permisos: {EsAdmin} | Fecha de creacion: {FechaCreacion:g}";
        }
    }
}
