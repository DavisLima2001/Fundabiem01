using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
  public  class GrupoFamiliar
    {
        public int IdGrupoFamiliar { get; set; }
        public string nombre { get; set; }
        public string eCivil { get; set; }
        public string relacion { get; set; }
        public int edad { get; set; }
        public string escolaridad { get; set; }
        public string ocupacion { get; set; }
        public decimal salario { get; set; }
        public int IdFichaEstudioEconomico { get; set; }
    }
}
