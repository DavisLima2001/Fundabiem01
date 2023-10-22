using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class Tratamiento
    {
        public int IdTablaTratamiento { get; set; }
        public string fecha { get; set; }
        public string tratamiento { get; set; }
        public string duracion { get; set; }
        public int no { get; set; }
        public string ft { get; set; }
        public int IdHistorialClinica { get; set; }

    }
}
