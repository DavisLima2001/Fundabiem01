using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
   public class CN_Estadisctica
    {
        public CD_Estadistica objCapaDato = new CD_Estadistica();



        public List<Estadistica> Listar()
        {
            return objCapaDato.Listar();
        }
        public Estadistica VerEstadisctica(string FechaRegistro)
        {

            return objCapaDato.VerEstadistica(FechaRegistro);
        }

        public int Registrar(Estadistica obj, out string Mensaje)
        {
            Mensaje = String.Empty;
            if (string.IsNullOrEmpty(obj.FechaRegistro) || string.IsNullOrWhiteSpace(obj.FechaRegistro))
            {
                Mensaje = "Compo fecha no se puede dejar vacio";
            }
            else if (string.IsNullOrEmpty(obj.horaInicio) || string.IsNullOrWhiteSpace(obj.horaInicio))
            {
                Mensaje = "El campo hora d no puede estar vacio";
            }
            else if (string.IsNullOrEmpty(obj.horaFin) || string.IsNullOrWhiteSpace(obj.horaFin))
            {
                Mensaje = "El campo hora a no puede estar vacio";
            }

            else if (obj.oEmpleado.IdEmpleado == 0)
            {
                Mensaje = "Tiene que asignar un ampleado";
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


        public bool Editar(Estadistica obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.IdEstadisticaDiaria == 0)
            {
                Mensaje = "Sigues bien los pasos, para actualizar debes buscar o bien guardar";
            }
           else if (string.IsNullOrEmpty(obj.FechaRegistro) || string.IsNullOrWhiteSpace(obj.FechaRegistro))
            {
                Mensaje = "Compo fecha no se puede dejar vacio";
            }
            else if (string.IsNullOrEmpty(obj.horaInicio) || string.IsNullOrWhiteSpace(obj.horaInicio))
            {
                Mensaje = "El campo hora d no puede estar vacio";
            }
            else if (string.IsNullOrEmpty(obj.horaFin) || string.IsNullOrWhiteSpace(obj.horaFin))
            {
                Mensaje = "El campo hora a no puede estar vacio";
            }

            else if (obj.oEmpleado.IdEmpleado == 0)
            {
                Mensaje = "Tiene que asignar un ampleado";
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
