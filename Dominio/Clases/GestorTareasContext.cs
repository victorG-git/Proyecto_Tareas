using Microsoft.EntityFrameworkCore;


namespace Proyecto_Tareas.Dominio.Clases
{
    public class GestorTareasContext : DbContext
    {
        public GestorTareasContext(DbContextOptions<GestorTareasContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Tarea> Tareas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer(
                    @"Server=localhost\MSSQLLocalDB;
                      Database=GestorTareas;
                      Trusted_Connection=True;
                      TrustServerCertificate=True;");
            }
        }
    }
}
