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
        public int Id { get; }
        public string Nombre { get; private set; }
        public string Email { get; private set; }
        private string Contrasenia { get; set; }
        public bool EsAdmin { get; private set; }
        public DateTime FechaCreacion { get; }
        public bool Activo { get; private set; }

        public Usuario(int id, string nombre, string email, string contrasenia, bool esAdmin)
        {
            Id = id;
            Nombre = nombre;
            Email = email;
            Contrasenia = contrasenia;
            EsAdmin = esAdmin;
            FechaCreacion = DateTime.Now;
            Activo = true;
        }

        public string ObtenerUsuario()
        {
            return $"[{Id}] {Nombre} | Email: {Email} | Admin: {EsAdmin} | Activo: {Activo} | Fecha: {FechaCreacion:g}";
        }

        public bool ValidarContrasenia(string contrasenia)
        {
            return Contrasenia == contrasenia;
        }

        public void CambiarContrasenia(string nuevaContrasenia)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(nuevaContrasenia);
            Contrasenia = nuevaContrasenia;
        }

        public void CambiarEmail(string nuevoEmail)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(nuevoEmail);
            Email = nuevoEmail;
        }

        public void Desactivar()
        {
            Activo = false;
        }

        public void Activar()
        {
            Activo = true;
        }
    }
}
