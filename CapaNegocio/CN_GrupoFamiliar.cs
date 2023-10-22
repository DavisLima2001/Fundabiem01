using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
  public  class CN_GrupoFamiliar
    {
        public CD_GrupoFamiliar objCapaDato = new CD_GrupoFamiliar();
        public BuscarGrupoFamiliar VerGrupoFamiliar(int IdFichaEstudioEconomico)
        {

            return objCapaDato.VerGrupoFamiliae(IdFichaEstudioEconomico);
        }

        public List<GrupoFamiliar> Listar2(int IdFichaEstudioEconomico)
        {
            return objCapaDato.Listar2(IdFichaEstudioEconomico);
        }

        public int Registrar(GrupoFamiliar obj, out string Mensaje)
        {
            Mensaje = String.Empty;
            if (obj.IdFichaEstudioEconomico == 0)
            {
                Mensaje = "No se puede agregar la persona, motivo si estas creando una ficha nueva primero tienes que guardarla, en caso que ya este creanda tienes que buscarla";
            }

           else if (string.IsNullOrEmpty(obj.nombre) || string.IsNullOrWhiteSpace(obj.nombre))
            {
                Mensaje = "El nombre no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.eCivil) || string.IsNullOrWhiteSpace(obj.eCivil))
            {
                Mensaje = "El eCivil no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.relacion) || string.IsNullOrWhiteSpace(obj.relacion))
            {
                Mensaje = "La relacion no puede ser vacio";
            }
            else if (obj.edad == 0)
            {
                Mensaje = "La edad  no TIENE QUE ESTAR VACIO";
            }

            else if (string.IsNullOrEmpty(obj.escolaridad) || string.IsNullOrWhiteSpace(obj.escolaridad))
            {
                Mensaje = "La escolaridad no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.ocupacion) || string.IsNullOrWhiteSpace(obj.ocupacion))
            {
                Mensaje = "La ocupacion no puede ser vacio";
            }
            else if (obj.salario == 0)
            {
                Mensaje = "El  salario no TIENE QUE ESTAR VACIO";
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


        public bool Editar(GrupoFamiliar obj, out string Mensaje)
        {
            Mensaje = String.Empty;

            if (obj.IdGrupoFamiliar == 0)
            {
                Mensaje = "Debes buscar primero";
            }

           else if (obj.IdFichaEstudioEconomico == 0)
            {
                Mensaje = "No se puede agregar la persona, motivo si estas creando una ficha nueva primero tienes que guardarla, en caso que ya este creanda tienes que buscarla";
            }

          else  if (string.IsNullOrEmpty(obj.nombre) || string.IsNullOrWhiteSpace(obj.nombre))
            {
                Mensaje = "El nombre no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.eCivil) || string.IsNullOrWhiteSpace(obj.eCivil))
            {
                Mensaje = "El eCivil no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.relacion) || string.IsNullOrWhiteSpace(obj.relacion))
            {
                Mensaje = "La relacion no puede ser vacio";
            }
            else if (obj.edad == 0)
            {
                Mensaje = "La edad  no TIENE QUE ESTAR VACIO";
            }

            else if (string.IsNullOrEmpty(obj.escolaridad) || string.IsNullOrWhiteSpace(obj.escolaridad))
            {
                Mensaje = "La escolaridad no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.ocupacion) || string.IsNullOrWhiteSpace(obj.ocupacion))
            {
                Mensaje = "La ocupacion no puede ser vacio";
            }
            else if (obj.salario == 0)
            {
                Mensaje = "El  salario no TIENE QUE ESTAR VACIO";
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
