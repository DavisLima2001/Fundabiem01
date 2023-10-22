using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;
namespace CapaNegocio
{
  public class CN_FichaHistorialClinica
    {
        private CP_FichaHistorialClinica objCapaDato = new CP_FichaHistorialClinica();

        public List<HistorialFichasClinica> Listar()
        {
            return objCapaDato.ListarHistorial();
        }

        public int Registrar(FichaHistorialClinica obj, out string Mensaje)
        {
            Mensaje = String.Empty;
            if (obj.IdHistorialClinica != 0)
            {
                Mensaje = "El ID DEL historial  TIENE QUE ESTAR VACIO";
            }
            else if (obj.IdUsuario == 0)
            {
                Mensaje = "Recuerda asignar el usuario";
            }
            else if (string.IsNullOrEmpty(obj.MotivoConsulta) || string.IsNullOrWhiteSpace(obj.MotivoConsulta))
            {
                Mensaje = "El motivo de consulta no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.AntecedentMadre) || string.IsNullOrWhiteSpace(obj.AntecedentMadre))
            {
                Mensaje = "los antecendentes de la madre  no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.e) || string.IsNullOrWhiteSpace(obj.e))
            {
                Mensaje = "el campo e no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.ab) || string.IsNullOrWhiteSpace(obj.ab))
            {
                Mensaje = "El campo ab no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.HijosVivos) || string.IsNullOrWhiteSpace(obj.HijosVivos))
            {
                Mensaje = "El campo hijos vivo no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.EstadoSaludHv) || string.IsNullOrWhiteSpace(obj.EstadoSaludHv))
            {
                Mensaje = "El estado de salud HV no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.HijosMuerteCausa) || string.IsNullOrWhiteSpace(obj.HijosMuerteCausa))
            {
                Mensaje = "El campor hijos muertos y las causas no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Padres) || string.IsNullOrWhiteSpace(obj.Padres))
            {
                Mensaje = "Los padres  no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Otros) || string.IsNullOrWhiteSpace(obj.Otros))
            {
                Mensaje = "Otros  no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.PesoNacer) || string.IsNullOrWhiteSpace(obj.PesoNacer))
            {
                Mensaje = "El peso al nacer no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.DuracionEmbarazo) || string.IsNullOrWhiteSpace(obj.DuracionEmbarazo))
            {
                Mensaje = "La duracion del embarazo no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.ProblemaGestional) || string.IsNullOrWhiteSpace(obj.ProblemaGestional))
            {
                Mensaje = "Problema gestional no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.MedicinaDuranteEmbarazo) || string.IsNullOrWhiteSpace(obj.MedicinaDuranteEmbarazo))
            {
                Mensaje = "Medicina Durante Embarazo no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Tabaquismo) || string.IsNullOrWhiteSpace(obj.Tabaquismo))
            {
                Mensaje = "Tabaquismo no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Alcohol) || string.IsNullOrWhiteSpace(obj.Alcohol))
            {
                Mensaje = "Alcohol no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.DuracionParto) || string.IsNullOrWhiteSpace(obj.DuracionParto))
            {
                Mensaje = "Duracion del parto no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.SufrimientoFetal) || string.IsNullOrWhiteSpace(obj.SufrimientoFetal))
            {
                Mensaje = "El sufrimiento fetal no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Vaginal) || string.IsNullOrWhiteSpace(obj.Vaginal))
            {
                Mensaje = "El campo vaginal no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Cesarea) || string.IsNullOrWhiteSpace(obj.Cesarea))
            {
                Mensaje = "La cesarea  no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.EstadoNacer) || string.IsNullOrWhiteSpace(obj.EstadoNacer))
            {
                Mensaje = "El estado al nacer no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Apgar) || string.IsNullOrWhiteSpace(obj.Apgar))
            {
                Mensaje = "El Apgar no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.SostenerCabeza) || string.IsNullOrWhiteSpace(obj.SostenerCabeza))
            {
                Mensaje = "Sostener cabeza no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Sonreir) || string.IsNullOrWhiteSpace(obj.Sonreir))
            {
                Mensaje = "Sonreir no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.RodarAlLado) || string.IsNullOrWhiteSpace(obj.RodarAlLado))
            {
                Mensaje = "Rodar al lado no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.SentarseSolo) || string.IsNullOrWhiteSpace(obj.SentarseSolo))
            {
                Mensaje = "Sentarse solo  no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Pararse) || string.IsNullOrWhiteSpace(obj.Pararse))
            {
                Mensaje = "Pararse no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Andar) || string.IsNullOrWhiteSpace(obj.Andar))
            {
                Mensaje = "Andar no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.CaminarSolo) || string.IsNullOrWhiteSpace(obj.CaminarSolo))
            {
                Mensaje = "Caminar solo no puede ser vacio";
            }

            else if (string.IsNullOrEmpty(obj.Hablar) || string.IsNullOrWhiteSpace(obj.Hablar))
            {
                Mensaje = "Hablar no puede ser vacio";
            }

            else if (string.IsNullOrEmpty(obj.Vacunaciones) || string.IsNullOrWhiteSpace(obj.Vacunaciones))
            {
                Mensaje = "Las vacunacones no puede ser vacio";
            }

            else if (string.IsNullOrEmpty(obj.Enfermedades) || string.IsNullOrWhiteSpace(obj.Enfermedades))
            {
                Mensaje = "Las enfermedades no puede ser vacio";
            }

            else if (string.IsNullOrEmpty(obj.AntecedentesQx) || string.IsNullOrWhiteSpace(obj.AntecedentesQx))
            {
                Mensaje = "Los antecedentes Qx no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Diagnosticos) || string.IsNullOrWhiteSpace(obj.Diagnosticos))
            {
                Mensaje = "Los diagnosticos no pueden estar vacios";
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

        public bool Editar(FichaHistorialClinica obj, out string Mensaje)
        {
            Mensaje = String.Empty;

            if (obj.IdHistorialClinica == 0)
            {
                Mensaje = "Recuerda que primero tiene que buscar al usuario";
            }
            else if (obj.IdUsuario == 0)
            {
                Mensaje = "Recuerda primero asignar el usuario";
            }
            else if (string.IsNullOrEmpty(obj.MotivoConsulta) || string.IsNullOrWhiteSpace(obj.MotivoConsulta))
            {
                Mensaje = "El motivo de consulta no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.AntecedentMadre) || string.IsNullOrWhiteSpace(obj.AntecedentMadre))
            {
                Mensaje = "los antecendentes de la madre  no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.e) || string.IsNullOrWhiteSpace(obj.e))
            {
                Mensaje = "el campo e no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.ab) || string.IsNullOrWhiteSpace(obj.ab))
            {
                Mensaje = "El campo ab no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.HijosVivos) || string.IsNullOrWhiteSpace(obj.HijosVivos))
            {
                Mensaje = "El campo hijos vivo no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.EstadoSaludHv) || string.IsNullOrWhiteSpace(obj.EstadoSaludHv))
            {
                Mensaje = "El estado de salud HV no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.HijosMuerteCausa) || string.IsNullOrWhiteSpace(obj.HijosMuerteCausa))
            {
                Mensaje = "El campor hijos muertos y las causas no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Padres) || string.IsNullOrWhiteSpace(obj.Padres))
            {
                Mensaje = "Los padres  no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Otros) || string.IsNullOrWhiteSpace(obj.Otros))
            {
                Mensaje = "Otros  no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.PesoNacer) || string.IsNullOrWhiteSpace(obj.PesoNacer))
            {
                Mensaje = "El peso al nacer no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.DuracionEmbarazo) || string.IsNullOrWhiteSpace(obj.DuracionEmbarazo))
            {
                Mensaje = "La duracion del embarazo no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.ProblemaGestional) || string.IsNullOrWhiteSpace(obj.ProblemaGestional))
            {
                Mensaje = "Problema gestional no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.MedicinaDuranteEmbarazo) || string.IsNullOrWhiteSpace(obj.MedicinaDuranteEmbarazo))
            {
                Mensaje = "Medicina Durante Embarazo no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Tabaquismo) || string.IsNullOrWhiteSpace(obj.Tabaquismo))
            {
                Mensaje = "Tabaquismo no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Alcohol) || string.IsNullOrWhiteSpace(obj.Alcohol))
            {
                Mensaje = "Alcohol no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.DuracionParto) || string.IsNullOrWhiteSpace(obj.DuracionParto))
            {
                Mensaje = "Duracion del parto no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.SufrimientoFetal) || string.IsNullOrWhiteSpace(obj.SufrimientoFetal))
            {
                Mensaje = "El sufrimiento fetal no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Vaginal) || string.IsNullOrWhiteSpace(obj.Vaginal))
            {
                Mensaje = "El campo vaginal no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Cesarea) || string.IsNullOrWhiteSpace(obj.Cesarea))
            {
                Mensaje = "La cesarea  no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.EstadoNacer) || string.IsNullOrWhiteSpace(obj.EstadoNacer))
            {
                Mensaje = "El estado al nacer no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Apgar) || string.IsNullOrWhiteSpace(obj.Apgar))
            {
                Mensaje = "El Apgar no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.SostenerCabeza) || string.IsNullOrWhiteSpace(obj.SostenerCabeza))
            {
                Mensaje = "Sostener cabeza no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Sonreir) || string.IsNullOrWhiteSpace(obj.Sonreir))
            {
                Mensaje = "Sonreir no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.RodarAlLado) || string.IsNullOrWhiteSpace(obj.RodarAlLado))
            {
                Mensaje = "Rodar al lado no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.SentarseSolo) || string.IsNullOrWhiteSpace(obj.SentarseSolo))
            {
                Mensaje = "Sentarse solo  no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Pararse) || string.IsNullOrWhiteSpace(obj.Pararse))
            {
                Mensaje = "Pararse no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Andar) || string.IsNullOrWhiteSpace(obj.Andar))
            {
                Mensaje = "Andar no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.CaminarSolo) || string.IsNullOrWhiteSpace(obj.CaminarSolo))
            {
                Mensaje = "Caminar solo no puede ser vacio";
            }

            else if (string.IsNullOrEmpty(obj.Hablar) || string.IsNullOrWhiteSpace(obj.Hablar))
            {
                Mensaje = "Hablar no puede ser vacio";
            }

            else if (string.IsNullOrEmpty(obj.Vacunaciones) || string.IsNullOrWhiteSpace(obj.Vacunaciones))
            {
                Mensaje = "Las vacunacones no puede ser vacio";
            }

            else if (string.IsNullOrEmpty(obj.Enfermedades) || string.IsNullOrWhiteSpace(obj.Enfermedades))
            {
                Mensaje = "Las enfermedades no puede ser vacio";
            }

            else if (string.IsNullOrEmpty(obj.AntecedentesQx) || string.IsNullOrWhiteSpace(obj.AntecedentesQx))
            {
                Mensaje = "Los antecedentes Qx no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Diagnosticos) || string.IsNullOrWhiteSpace(obj.Diagnosticos))
            {
                Mensaje = "Los diagnosticos no pueden estar vacios";
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



        public bool EditarDiagnisticos(FichaHistorialClinica obj, out string Mensaje)
        {
            Mensaje = String.Empty;

            if (obj.IdHistorialClinica == 0)
            {
                Mensaje = "Historia clinica No.: esta vacio";
            }
        
            else if (string.IsNullOrEmpty(obj.Diagnosticos) || string.IsNullOrWhiteSpace(obj.Diagnosticos))
            {
                Mensaje = "Los diagnosticos no pueden estar vacios";
            }


            if (string.IsNullOrEmpty(Mensaje))
            {

                return objCapaDato.EditarDiagnosticos(obj, out Mensaje);
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
