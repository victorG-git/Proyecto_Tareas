using Proyecto_Tareas.Aplicacion.Servicio.Proyecto_Tareas.Aplicacion.Servicio;

namespace Proyecto_Tareas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Registrar servicios
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Registrar DbContext
            builder.Services.AddDbContext<GestorTareasContext>();

            var app = builder.Build();

            // Configurar pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}