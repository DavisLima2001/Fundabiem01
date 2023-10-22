using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
   public class CN_Acceso
    {
        public CD_Acesso objCapaDato = new CD_Acesso();


        public List<Acceso> Listar()
        {
            return objCapaDato.Listar();
        }

        public int Registrar(Acceso obj, out string Mensaje)
        {
            Mensaje = String.Empty;
            if (string.IsNullOrEmpty(obj.Correo) || string.IsNullOrWhiteSpace(obj.Correo))
            {
                Mensaje = "El correo no puede estar vacio";
            }
            else if (string.IsNullOrEmpty(obj.Contraseña) || string.IsNullOrWhiteSpace(obj.Contraseña))
            {
                Mensaje = "La contraseña no puede estar vacia";
            }
            
            else if (obj.oEmpleado.IdEmpleado == 0)
            {
                Mensaje = "Tiene que asignar un ampleado";
            }






            if (string.IsNullOrEmpty(Mensaje))
            {
                obj.Contraseña = CN_Recursos.ConvertirSha256(obj.Contraseña);
                return objCapaDato.Registrar(obj, out Mensaje);

            }
            else
            {


                return 0;
            }

        }

        public bool Editar(Acceso obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.IdAcceso == 0)
            {
                Mensaje = "el identidicar del acceso no puestar vacio";
            }

            if (string.IsNullOrEmpty(obj.Correo) || string.IsNullOrWhiteSpace(obj.Correo))
            {
                Mensaje = "El correo no puede estar vacio";
            }
           

            else if (obj.oEmpleado.IdEmpleado == 0)
            {
                Mensaje = "Tiene que asignar un ampleado";
            }





            if (string.IsNullOrEmpty(Mensaje))
            {
                if (!string.IsNullOrEmpty(obj.Contraseña))
                {
                    obj.Contraseña = CN_Recursos.ConvertirSha256(obj.Contraseña);
                }
                

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
