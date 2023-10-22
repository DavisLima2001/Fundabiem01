using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Capa para el ingreso */
namespace CapaEntidad
{
   public class Acceso
    {
     
        public int IdAcceso { get; set; }
        public string Fecha { get; set; }
 
        public string Correo { get; set; }
        public string NombrPuesto { get; set; }
        public bool Activo { get; set; }
        public string Contraseña { get; set; }
        public Empleado oEmpleado { get; set; }
    }
}
