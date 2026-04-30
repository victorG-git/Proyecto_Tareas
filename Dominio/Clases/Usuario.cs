using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    namespace Proyecto_Tareas.Dominio.Clases
    {
        public class Usuario
        {
            public int Id { get; set; }
            public string Nombre { get; protected set; } = string.Empty;
            public string Email { get; protected set; } = string.Empty;
            public string Contrasenia { get; private set; } = string.Empty;
            public bool EsAdmin { get; protected set; }
            public DateTime FechaCreacion { get; protected set; } = DateTime.Now;
            public bool Activo { get; protected set; }

            // Constructor vacío requerido por EF
            public Usuario() { }

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

            public void Desactivar() => Activo = false;
            public void Activar() => Activo = true;
        }
    }