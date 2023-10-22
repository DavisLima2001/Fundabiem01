using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;


namespace CapaNegocio
{
  public  class CN_BuscarFiHistorialMedica
    {
       public  CD_BuscarFiHistorialClinica objCapaDato = new CD_BuscarFiHistorialClinica();
        public BuscarFiHistorialClinica VerFichaHistorialMedica(int IdHistorialClinica)
        {

            return objCapaDato.VerFiHistorialClinica( IdHistorialClinica);
        }


    }
}
