using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
  public  class CN_Tratamiento
    {
        private CD_Tratamiento objCapaDato = new CD_Tratamiento();

        public List<Tratamiento> Listar()
        {
            return objCapaDato.Listar();
        }
        public List<Tratamiento> Listar2(int IdHistorialClinica)
        {
            return objCapaDato.Listar2(IdHistorialClinica);
        }
        public int Registrar(Tratamiento obj, out string Mensaje)
        {
            Mensaje = String.Empty;
            if (obj.IdHistorialClinica == 0)
            {
                Mensaje = "Primero tiene que guardar el historial clinica para luego poder asignar los tratamiento";
            }

          else  if (string.IsNullOrEmpty(obj.tratamiento) || string.IsNullOrWhiteSpace(obj.tratamiento))
            {
                Mensaje = "El tratamiento no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.duracion) || string.IsNullOrWhiteSpace(obj.duracion))
            {
                Mensaje = "la la duracion  no puede ser vacio";
            }
            else if (obj.no==0)
            {
                Mensaje = "El campo no, no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.ft) || string.IsNullOrWhiteSpace(obj.ft))
            {
                Mensaje = "ft no puede ser vacio";
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

        public bool Editar(Tratamiento obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.tratamiento) || string.IsNullOrWhiteSpace(obj.tratamiento))
            {
                Mensaje = "El tratamiento no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.duracion) || string.IsNullOrWhiteSpace(obj.duracion))
            {
                Mensaje = "la la duracion  no puede ser vacio";
            }
            else if (obj.no == 0)
            {
                Mensaje = "El campo no, no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.ft) || string.IsNullOrWhiteSpace(obj.ft))
            {
                Mensaje = "ft no puede ser vacio";
            }
            else if (obj.IdHistorialClinica == 0)
            {
                Mensaje = "IdHistorialClinica, no puede ser vacio";
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
