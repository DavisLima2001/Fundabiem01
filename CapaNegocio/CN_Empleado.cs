using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;
namespace CapaNegocio
{
   public class CN_Empleado
    {
        public CD_Empleado objCapaDato = new CD_Empleado();


        public List<Empleado> Listar()
        {
            return objCapaDato.Listar();
        }


        public int Registrar(Empleado obj, out string Mensaje)
        {
            Mensaje = String.Empty;
            if (string.IsNullOrEmpty(obj.PrimerNombre) || string.IsNullOrWhiteSpace(obj.PrimerNombre))
            {
                Mensaje = "No debes dejar el primer nombre del empleado vacio";
            }
            else if (string.IsNullOrEmpty(obj.SegundoNombre) || string.IsNullOrWhiteSpace(obj.SegundoNombre))
            {
                Mensaje = "No debes dejar el segundo nombre del empleado vacio";
            }
            else if (string.IsNullOrEmpty(obj.PrimerApellido) || string.IsNullOrWhiteSpace(obj.PrimerApellido))
            {
                Mensaje = "No debes dejar el primer apellido del empleado vacio";
            }
            else if (string.IsNullOrEmpty(obj.SegundoApellido) || string.IsNullOrWhiteSpace(obj.SegundoApellido))
            {
                Mensaje = "No debes dejar el segundo apellido del empleado vacio";
            }
            else if (string.IsNullOrEmpty(obj.SegundoApellido) || string.IsNullOrWhiteSpace(obj.SegundoApellido))
            {
                Mensaje = "No debes dejar el segundo apellido del empleado vacio";
            }
           else if (obj.oPuesto.IdPuesto == 0)
            {
                Mensaje = "El id del puesto no puede estar vacio";
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

        public bool Editar(Empleado obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.IdEmpleado == 0)
            {
                Mensaje = "El id del empleado no puede estar vacio";
            }

          else  if (string.IsNullOrEmpty(obj.PrimerNombre) || string.IsNullOrWhiteSpace(obj.PrimerNombre))
            {
                Mensaje = "No debes dejar el primer nombre del empleado vacio";
            }
            else if (string.IsNullOrEmpty(obj.SegundoNombre) || string.IsNullOrWhiteSpace(obj.SegundoNombre))
            {
                Mensaje = "No debes dejar el segundo nombre del empleado vacio";
            }
            else if (string.IsNullOrEmpty(obj.PrimerApellido) || string.IsNullOrWhiteSpace(obj.PrimerApellido))
            {
                Mensaje = "No debes dejar el primer apellido del empleado vacio";
            }
            else if (string.IsNullOrEmpty(obj.SegundoApellido) || string.IsNullOrWhiteSpace(obj.SegundoApellido))
            {
                Mensaje = "No debes dejar el segundo apellido del empleado vacio";
            }
            else if (string.IsNullOrEmpty(obj.SegundoApellido) || string.IsNullOrWhiteSpace(obj.SegundoApellido))
            {
                Mensaje = "No debes dejar el segundo apellido del empleado vacio";
            }
            else if (obj.oPuesto.IdPuesto == 0)
            {
                Mensaje = "El id del puesto no puede estar vacio";
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

