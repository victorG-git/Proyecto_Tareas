using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Tareas.Dominio.Clases
{
    internal class Usuario
    { 
        private int Id { get; set; }
        private string Nombre { get; set; }
        private string Email { get; set; }
        private string Pasword { get; set; }
        private bool EsAdmin { get; set; }
        private DateTime FechaCreacion { get; set; }




    }
}
