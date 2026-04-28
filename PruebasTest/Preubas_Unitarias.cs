using System;
using NUnit.Framework;
using Proyecto_Tareas.Dominio.Clases;

namespace Proyecto_Tareas.PruebasTest
{
    public class Pruebas_Unitarias
    {
        private Tarea tarea;

        [SetUp]
        public void Setup()
        {
            tarea = new Tarea(
                1,
                "Tarea de prueba",
                "Descripcion de prueba",
                DateTime.Now.AddDays(2),
                PrioridadTarea.Media
            );
        }

        [Test]
        public void CrearTareaComoPendiente()
        {
            Assert.That(tarea.Estado, Is.EqualTo(EstadoTarea.Pendiente));
        }

        [Test]
        public void IniciarTareaEnProgreso()
        {
            tarea.Iniciar();

            Assert.That(tarea.Estado, Is.EqualTo(EstadoTarea.EnProgreso));
        }

        [Test]
        public void FinalizarTareaACompletado()
        {
            tarea.Iniciar();
            tarea.Finalizar();

            Assert.That(tarea.Estado, Is.EqualTo(EstadoTarea.Completado));
            Assert.That(tarea.fechaFinalizacion, Is.Not.Null);
        }

        [Test]
        public void AgregarSubtarea()
        {
            Tarea subtarea = new Tarea(
                2,
                "Subtarea",
                "Descripcion de subtarea",
                DateTime.Now.AddDays(1),
                PrioridadTarea.Alta
            );

            tarea.AgregarSubtarea(subtarea);

            Assert.That(tarea.Subtareas.Count, Is.EqualTo(1));
        }

        [Test]
        public void GestorTareaPorId()
        {
            GestorTareas gestor = new GestorTareas();
            gestor.AgregarTarea(tarea);

            Tarea? resultado = gestor.BuscarPorId(1);

            Assert.That(resultado, Is.Not.Null);
            Assert.That(resultado.Id, Is.EqualTo(1));
        }
            /*
        [Test]
        public void PareaProgramada() 
        {
            TareaProgramada programar = new TareaProgramada();
            programar.AgregarSubtarea();

        
        }*/
    }
}