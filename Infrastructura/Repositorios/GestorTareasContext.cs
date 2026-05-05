using Microsoft.EntityFrameworkCore;
using Proyecto_Tareas.Dominio.Clases;

namespace Proyecto_Tareas.Infrastructura.Repositorios
{
    public class GestorTareasContext : DbContext
    {
            public GestorTareasContext(DbContextOptions<GestorTareasContext> options)
                : base(options) { }

            public DbSet<Usuario> Usuarios { get; set; }
            public DbSet<Tarea> Tareas { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                // ✔️ Relación Usuario - Tareas
                modelBuilder.Entity<Tarea>()
                    .HasOne(t => t.Usuario)
                    .WithMany()
                    .HasForeignKey(t => t.UsuarioId);

                // ✔️ Relación jerárquica
                modelBuilder.Entity<Tarea>()
                    .HasOne(t => t.TareaPadre)
                    .WithMany(t => t.Subtareas)
                    .HasForeignKey(t => t.TareaPadreId)
                    .OnDelete(DeleteBehavior.Restrict);

                // ✔️ Herencia (TPH)
                modelBuilder.Entity<Tarea>()
                    .HasDiscriminator<string>("TipoTarea")
                    .HasValue<Tarea>("Base")
                    .HasValue<TareaSimple>("Simple")
                    .HasValue<TareaProgramada>("Programada")
                    .HasValue<TareaConSubtarea>("Subtarea");
            }

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
