namespace Proyecto_Tareas.Aplicacion.DTOs
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Contrasenia { get; set; }
        public bool EsAdmin { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Activo { get; set; }

        public UsuarioDto(int id, string nombre, string email, string contrasenia, bool esAdmin, DateTime fechaCreacion, bool activo)
        {
            Id = id;
            Nombre = nombre;
            Email = email;
            Contrasenia = contrasenia;
            EsAdmin = esAdmin;
            FechaCreacion = fechaCreacion;
            Activo = activo;
        }
    }
}
