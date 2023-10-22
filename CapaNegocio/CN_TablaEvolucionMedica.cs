using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
  public  class CN_TablaEvolucionMedica
    {
        private CD_TablaEvolucionMedica objCapaDato = new CD_TablaEvolucionMedica();

        public List<TablaEvolucionMedica> Listar()
        {
            return objCapaDato.Listar();
        }
        public List<TablaEvolucionMedica> Listar2(int IdFichaEvolucionMedica)
        {
            return objCapaDato.Listar2(IdFichaEvolucionMedica);
        }


        public int Registrar(TablaEvolucionMedica obj, out string Mensaje)
        {
            Mensaje = String.Empty;
            if (obj.IdFichaEvolucionMedica == 0)
            {
                Mensaje = "Para este proceso tiene que buscar la hoja de evolucion medica";
            }

            else if (string.IsNullOrEmpty(obj.columna1) || string.IsNullOrWhiteSpace(obj.columna1))
            {
                Mensaje = "El campo No no puestar vacio";
            }
            else if (string.IsNullOrEmpty(obj.columna2) || string.IsNullOrWhiteSpace(obj.columna2))
            {
                Mensaje = "El campo descripcion no puede estar vacio";
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


        public bool Editar(TablaEvolucionMedica obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.IdTablaEvolucionMedica == 0)
            {
                Mensaje = "esta vacion el el identificador de la tabla";
            }
         else   if (obj.IdFichaEvolucionMedica == 0)
            {
                Mensaje = "Para este proceso tiene que buscar la hoja de evolucion medica";
            }

            else if (string.IsNullOrEmpty(obj.columna1) || string.IsNullOrWhiteSpace(obj.columna1))
            {
                Mensaje = "El campo No no puestar vacio";
            }
            else if (string.IsNullOrEmpty(obj.columna2) || string.IsNullOrWhiteSpace(obj.columna2))
            {
                Mensaje = "El campo descripcion no puede estar vacio";
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
