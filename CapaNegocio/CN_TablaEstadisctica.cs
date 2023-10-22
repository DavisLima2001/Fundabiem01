using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;
namespace CapaNegocio
{
  public  class CN_TablaEstadisctica
    {
        private CD_TablaEstadistica objCapaDato = new CD_TablaEstadistica();


        public List<BuscarTablaEstadistica> Listar2(string FechaRegistro)
        {
            return objCapaDato.Listar2(FechaRegistro);
        }
        public List<BuscarTablaEstadistica> Listar3(string FechaInicio, string FechaFin)
        {
            return objCapaDato.Listar3(FechaInicio, FechaFin);
        }
        public int Registrar(TablaEstadistica obj, out string Mensaje)
        {
            Mensaje = String.Empty;
            if (obj.IdEstadisticaDiaria == 0)
            {
                Mensaje = "Error: Antes de agregar un nuevo registro a la estadística, es imperativo identificar la fecha en que se registró inicialmente dicha estadística. Por favor, realice una búsqueda de la fecha de registro correspondiente antes de proceder con la inserción del nuevo dato";
            }
           else if (obj.no == 0)
            {
                Mensaje = "El campo no no puede estar vacio";
            }
            else if (obj.OFichaHistorialClinica.IdHistorialClinica== 0)
            {
                Mensaje = "Debe seleccionar el historial clinico del paciente";
            }

            else if (string.IsNullOrEmpty(obj.Diagnostico) || string.IsNullOrWhiteSpace(obj.Diagnostico))
            {
                Mensaje = "El campor diagnostico no puede esta vacio";
            }
            else if (string.IsNullOrEmpty(obj.Consulta) || string.IsNullOrWhiteSpace(obj.Consulta))
            {
                Mensaje = "El campo consulta no puede estar vacio";
            }
            
            else if (string.IsNullOrEmpty(obj.ConsTras) || string.IsNullOrWhiteSpace(obj.ConsTras))
            {
                Mensaje = "Debe selecionar en ConsTras";
            }
            else if (string.IsNullOrEmpty(obj.RaOrtesis) || string.IsNullOrWhiteSpace(obj.RaOrtesis))
            {
                Mensaje = "Debe selecionar en RaOrtesis";
            }
            else if (string.IsNullOrEmpty(obj.Comentario) || string.IsNullOrWhiteSpace(obj.Comentario))
            {
                Mensaje = "No puede dejar vacio el comentario";
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

        public bool Editar(TablaEstadistica obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.IdTabEstadistica == 0)
            {
                Mensaje = "el id de la tabla no puede estar vacio as bien los proceesos ";
            }

            else if (obj.IdEstadisticaDiaria == 0)
            {
                Mensaje = "Primero tiene que guardar  la estadistica";
            }
            else if (obj.no == 0)
            {
                Mensaje = "El campo no no puede estar vacio";
            }
            else if (obj.OFichaHistorialClinica.IdHistorialClinica == 0)
            {
                Mensaje = "Debe seleccionar el historial clinico del paciente";
            }

            else if (string.IsNullOrEmpty(obj.Diagnostico) || string.IsNullOrWhiteSpace(obj.Diagnostico))
            {
                Mensaje = "El campor diagnostico no puede esta vacio";
            }
            else if (string.IsNullOrEmpty(obj.Consulta) || string.IsNullOrWhiteSpace(obj.Consulta))
            {
                Mensaje = "El campo consulta no puede estar vacio";
            }
            else if (string.IsNullOrEmpty(obj.RaOrtesis) || string.IsNullOrWhiteSpace(obj.RaOrtesis))
            {
                Mensaje = "Debe selecionar en RaOrtesis";
            }

            else if (string.IsNullOrEmpty(obj.ConsTras) || string.IsNullOrWhiteSpace(obj.ConsTras))
            {
                Mensaje = "Debe selecionar en ConsTras";
            }
            else if (string.IsNullOrEmpty(obj.Comentario) || string.IsNullOrWhiteSpace(obj.Comentario))
            {
                Mensaje = "No puede dejar vacio el comentario";
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
