using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
   public class CN_Puesto
    {
        public CD_Puesto objCapaDato = new CD_Puesto();


        public List<Puesto> Listar()
        {
            return objCapaDato.Listar();
        }

        public int Registrar(Puesto obj, out string Mensaje)
        {
            Mensaje = String.Empty;
            if (string.IsNullOrEmpty(obj.NombrPuesto) || string.IsNullOrWhiteSpace(obj.NombrPuesto))
            {
                Mensaje = "No debes dejar el nombre del puesto vacio";
            }
           



            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.Registrar(obj, out Mensaje);

            }
            else
            {


                return 0;
            }

        }


        public bool Editar(Puesto obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.IdPuesto == 0)
            {
                Mensaje = "El id del puesto no puede estar vacio";
            }
            else if (string.IsNullOrEmpty(obj.NombrPuesto) || string.IsNullOrWhiteSpace(obj.NombrPuesto))
            {
                Mensaje = "No debes dejar el nombre del puesto vacio";
            }




            if (string.IsNullOrEmpty(Mensaje))
            {

                return objCapaDato.Editar(obj, out Mensaje);
            }
            else
            {
                return false;
            }
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return objCapaDato.Eliminar(id, out Mensaje);
        }


    }
}
