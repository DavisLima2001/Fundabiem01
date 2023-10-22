using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;
namespace CapaNegocio
{
    public class CN_FichaEvolucionMedica
    {
        private CD_FichaEvolucionMedica objCapaDato = new CD_FichaEvolucionMedica();


        public List<BuscarFichaEvolucionMedica2> Listar()
        {
            return objCapaDato.Listar();
        }

        public BuscarFichaEvolucionMedica2 VerFichaEvolucionMedica2(int IdFichaEvolucionMedica)
        {

            return objCapaDato.VerFichaEvolucionMedica2(IdFichaEvolucionMedica);
        }


        public BuscarFichaEvolucionMedica VerFichaEvolucionMedica(int IdHistorialClinica)
        {

            return objCapaDato.VerFichaEvolucionMedica(IdHistorialClinica);
        }


        public int Registrar(FichaEvolucionMedica obj, out string Mensaje)
        {
            Mensaje = String.Empty;
            if (obj.IdHistorialClinica == 0)
            {
                Mensaje = "Recuerda que tienes que asignar el historial clinico a la evolucion medica";
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


        public bool Editar(FichaEvolucionMedica obj, out string Mensaje)
        {
            Mensaje = String.Empty;

            if (obj.IdFichaEvolucionMedica == 0)
            {
                Mensaje = "Recuerda que primero tiene que buscar la ficha de evolucion para poder actualizar";
            }
            else if (obj.IdHistorialClinica == 0)
            {
                Mensaje = "Recuerda primero asignar el el historial clinico a la ficha evolucion medica";
            }
            else if (string.IsNullOrEmpty(obj.Diagnostico) || string.IsNullOrWhiteSpace(obj.Diagnostico))
            {
                Mensaje = "No dejar el campo diagnotisco tiene que especificar algo....";
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
