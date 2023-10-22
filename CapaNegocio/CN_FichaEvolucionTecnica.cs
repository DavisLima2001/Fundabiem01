using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;


namespace CapaNegocio
{
   public class CN_FichaEvolucionTecnica
    {
        private CD_FichaEvolucionTecnica objCapaDato = new CD_FichaEvolucionTecnica();



        public List<BuscarFichaEvolucionTecnica> Listar()
        {
            return objCapaDato.Listar();
        }

        public BuscarFichaEvolucionTecnica VerFichaEvolucionTecnica(int IdFichaEvolucionTecnica)
        {

            return objCapaDato.VerFichaEvolucionTecnia(IdFichaEvolucionTecnica);
        }
        public int Registrar(FichaEvolucionTenica obj, out string Mensaje)
        {
            Mensaje = String.Empty;
            if (obj.IdHistorialClinica == 0)
            {
                Mensaje = "Recuerda que tienes que asignar el historial clinico a la evolucion tecnica";
            }
            else if (string.IsNullOrEmpty(obj.Diagnostico) || string.IsNullOrWhiteSpace(obj.Diagnostico))
            {
                Mensaje = "No dejar el campo diagnotisco tiene que especificar algo....";
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


        public bool Editar(FichaEvolucionTenica obj, out string Mensaje)
        {
            Mensaje = String.Empty;

            if (obj.IdFichaEvolucionTecnica == 0)
            {
                Mensaje = "Recuerda que primero tiene que buscar la ficha de evolucion tecnica";
            }
            else if (obj.IdHistorialClinica == 0)
            {
                Mensaje = "Recuerda primero asignar el el historial clinico a la ficha evolucion";
            }

            else if (string.IsNullOrEmpty(obj.Diagnostico) || string.IsNullOrWhiteSpace(obj.Diagnostico))
            {
                Mensaje = "No dejar el campo diagnotisco vacio, tiene que especificar algo....";
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
