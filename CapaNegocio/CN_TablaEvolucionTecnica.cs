using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;


namespace CapaNegocio
{
 public   class CN_TablaEvolucionTecnica
    {

        private CD_TablaEvolucionTecnica objCapaDato = new CD_TablaEvolucionTecnica();

        public List<TablaEvolucionTecnica> Listar2(int IdFichaEvolucionTecnica)
        {
            return objCapaDato.Listar2(IdFichaEvolucionTecnica);
        }

        public int Registrar(TablaEvolucionTecnica obj, out string Mensaje)
        {
            Mensaje = String.Empty;
            if (obj.IdFichaEvolucionTecnica == 0)
            {
                Mensaje = "Recuerda que para ser este proceso tiene que buscar la hoja  evolucion tecnica primero";
            }

            else if (string.IsNullOrEmpty(obj.columna1) || string.IsNullOrWhiteSpace(obj.columna1))
            {
                Mensaje = "No debes dejar  vacio el campo No";
            }
            else if (string.IsNullOrEmpty(obj.columna2) || string.IsNullOrWhiteSpace(obj.columna2))
            {
                Mensaje = "No debes dejar vacio el campo descripcion";
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

        public bool Editar(TablaEvolucionTecnica obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.IdTablaEvolucionTecnica == 0)
            {
                Mensaje = "esta vacio el el identificador de la tabla tecnica";
            }
            else if (obj.IdFichaEvolucionTecnica == 0)
            {
                Mensaje = "Recuerda que para ser este proceso tiene que buscar la hoja  evolucion tecnica primero";
            }

            else if (string.IsNullOrEmpty(obj.columna1) || string.IsNullOrWhiteSpace(obj.columna1))
            {
                Mensaje = "No debes dejar  vacio el campo No";
            }
            else if (string.IsNullOrEmpty(obj.columna2) || string.IsNullOrWhiteSpace(obj.columna2))
            {
                Mensaje = "No debes dejar vacio el campo descripcion";
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
