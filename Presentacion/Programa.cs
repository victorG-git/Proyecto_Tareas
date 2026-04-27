using System;
using Proyecto_Tareas.Dominio;
using Proyecto_Tareas.Dominio.Clases;

namespace Proyecto_Tareas
{
    internal class Program
    {
      /*  static void Main(string[] args)
        {
            GestorTareas gestor = new GestorTareas();

            try
            {
                gestor.CargarDatos();

                if (gestor.ObtenerTareas().Count == 0)
                {
                    Tarea tarea1 = new Tarea(
                        1,
                        "Leer tema de C#",
                        "Repasar clases abstractas y encapsulamiento",
                        DateTime.Now.AddDays(3),
                        PrioridadTarea.Media
                    );

                    Tarea tarea2 = new Tarea(
                        2,
                        "Entregar practica",
                        "Subir el proyecto terminado al repositorio",
                        DateTime.Now.AddHours(5),
                        PrioridadTarea.PrioridadMaxima
                    );

                    Tarea tarea3 = new Tarea(
                        3,
                        "Preparar examen",
                        "Estudiar los temas 1, 2 y 3",
                        DateTime.Now.AddDays(7),
                        PrioridadTarea.Alta
                    );

                    gestor.AgregarTarea(tarea1);
                    gestor.AgregarTarea(tarea2);
                    gestor.AgregarTarea(tarea3);

                    Console.WriteLine("No habia tareas guardadas, asi que se han creado tareas de ejemplo.");
                }
                else
                {
                    Console.WriteLine("Se han cargado las tareas guardadas.");
                }

                Console.WriteLine();
                Console.WriteLine("Tareas actuales:");
                Console.WriteLine();

                foreach (Tarea tarea in gestor.ObtenerTareas())
                {
                    Console.WriteLine(tarea.ObtenerResumen());
                }

                gestor.GuardarDatos();

                Console.WriteLine();
                Console.WriteLine("Las tareas se han guardado correctamente en el archivo JSON.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido un error.");
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();
            Console.WriteLine("Pulsa una tecla para cerrar.");
            Console.ReadKey();
        }*/
    }
}