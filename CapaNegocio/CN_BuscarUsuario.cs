using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;
namespace CapaNegocio
{
  public  class CN_BuscarUsuario
    {
        private CD_BuscarUsuario objCapaDato = new CD_BuscarUsuario();
        public BuscarUsuario VerUsuario(string PrimerApellido,string PrimerNombre)
        {

            return objCapaDato.VerUsuario(PrimerApellido, PrimerNombre);
        }
    }
}
