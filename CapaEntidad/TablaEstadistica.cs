using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
  public  class TablaEstadistica
    {
        public int IdTabEstadistica { get; set; }
        public int no { get; set; }

        public FichaHistorialClinica OFichaHistorialClinica { get; set; }
        public int IdEstadisticaDiaria { get; set; }
        public string Diagnostico { get; set; }
        public string Consulta { get; set; }
        public string ConsTras { get; set; }
        public string RaOrtesis { get; set; }
        public string Comentario { get; set; }
        


    }
}
