using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
  public  class BuscarFichaEvolucionMedica2
    {
        public int IdFichaEvolucionMedica { get; set; }
        public int IdHistorialClinica { get; set; }
        public string PrimerApellido { get; set; }
        public string fechaRegistro { get; set; }
        public string SegundoApellido { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }
        public string Diagnostico { get; set; }

    }
}
