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
                modelBuilder.Entity<Tarea>()
                    .HasOne(t => t.Usuario)
                    .WithMany()
                    .HasForeignKey(t => t.UsuarioId);

                modelBuilder.Entity<Tarea>()
                    .HasOne(t => t.TareaPadre)
                    .WithMany(t => t.Subtareas)
                    .HasForeignKey(t => t.TareaPadreId)
                    .OnDelete(DeleteBehavior.Restrict);
                
            modelBuilder.Entity<Tarea>()
                    .HasDiscriminator<string>("TipoTarea")
                    .HasValue<Tarea>("Base")
                    .HasValue<TareaSimple>("Simple")
                    .HasValue<TareaProgramada>("Programada")
                    .HasValue<TareaConSubtarea>("Subtarea");
            }
    }
}
