using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class Estadistica
    {
        public int IdEstadisticaDiaria { get; set; }
        public string FechaRegistro { get; set; }

        public string horaInicio { get; set; }
        public string horaFin { get; set; }

        public Empleado oEmpleado { get; set; }
    }
}
