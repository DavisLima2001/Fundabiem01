using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
  public   class FichaHistorialClinica
    {
        public int IdHistorialClinica { get; set; }
        public string Fecha { get; set; } 
        public int IdUsuario { get; set; }
        public string MotivoConsulta { get; set; }
        public string AntecedentMadre { get; set; }
        public string e { get; set; }
        public string ab { get; set; }
        public string HijosVivos { get; set; }
        public string EstadoSaludHv { get; set; }
        public string HijosMuerteCausa { get; set; }
        public string Padres { get; set; }
        public string Otros { get; set; }
        public string PesoNacer { get; set; }
        public string DuracionEmbarazo { get; set; }
        public string ProblemaGestional { get; set; }
        public string MedicinaDuranteEmbarazo { get; set; }
        public string Tabaquismo { get; set; }
        public string Alcohol { get; set; }
        public string DuracionParto { get; set; }
        public string SufrimientoFetal { get; set; }
        public string Vaginal { get; set; }
        public string Cesarea { get; set; }
        public string EstadoNacer { get; set; }
        public string Apgar { get; set; }
        public string SostenerCabeza { get; set; }
        public string Sonreir { get; set; }
        public string RodarAlLado { get; set; }
        public string SentarseSolo { get; set; }
        public string Pararse { get; set; }
        public string Andar { get; set; }
        public string CaminarSolo { get; set; }
        public string Hablar { get; set; }
        public string Vacunaciones { get; set; }
        public string Enfermedades { get; set; }
        public string AntecedentesQx { get; set; }
        public string Diagnosticos { get; set; }
    }
}
