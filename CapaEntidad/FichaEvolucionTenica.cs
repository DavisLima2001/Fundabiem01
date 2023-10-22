using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
  public  class FichaEvolucionTenica
    {

        public int IdFichaEvolucionTecnica { get; set; }
        public string Diagnostico { get; set; }
        public int IdHistorialClinica { get; set; }
        public string fechaRegistro { get; set; }
    }
}
