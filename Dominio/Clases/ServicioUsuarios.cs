using Microsoft.VisualStudio.TestPlatform.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_Tareas.Dominio.Clases
{
    internal class ServicioUsuarios
    {
        private List<Usuario> usuarios = new();
        private Dictionary<int, Usuario> identificadorUsuario = new();

        public void RegistrarUsuario(Usuario usuario)
        {
            ArgumentNullException.ThrowIfNull(usuario);

            if (!identificadorUsuario.TryAdd(usuario.Id, usuario))
                throw new ArgumentException($"Ya existe un usuario con id {usuario.Id}.");

            usuarios.Add(usuario);
        }

        public Usuario? Login(string nombre, string contrasenia)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(nombre);
            ArgumentException.ThrowIfNullOrWhiteSpace(contrasenia);

            var usuario = usuarios.FirstOrDefault(u => u.Nombre == nombre);

            if (usuario == null)
                return null;

            if (usuario.contrasenia != contrasenia)
                return null;

            if (!usuario.Activo)
                throw new InvalidOperationException("El usuario está desactivado.");

            return usuario;
        }

        public Usuario? ObtenerPorId(int id)
        {
            if (identificadorUsuario.TryGetValue(id, out var usuario))
                return usuario;

            return null;
        }

        public void DesactivarUsuario(int id)
        {
            var usuario = ObtenerPorId(id);

            if (usuario == null)
                throw new KeyNotFoundException($"No existe un usuario con id {id}.");

            usuario.Activo = false;
        }

    }
}
