using Microsoft.EntityFrameworkCore;
using Proyecto_Tareas.Infrastructura.Repositorios;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<GestorTareasContext>(options =>
options.UseSqlServer(
builder.Configuration.GetConnectionString("GestorTareas")
)
);

var app = builder.Build();


    app.UseSwagger();
    app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
