using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_FichaEstudioSocioeconomico
    {
        private CD_FichaEstudiSocioeconomico objCapaDato = new CD_FichaEstudiSocioeconomico();

        public List<HistorialFichasEstudio> Listar()
        {
            return objCapaDato.ListarHistorial();
        }


        public BuscarFichaEstudio VerFichaEstudio(int IdFichaEstudioEconomico)
        {

            return objCapaDato.VerFiHaEstudio(IdFichaEstudioEconomico);
        }

        public int Registrar(FichaEstudioSocioeconomico obj, out string Mensaje)
        {
            Mensaje = String.Empty;

            if (obj.IdFichaEstudioEconomico != 0)
            {
                Mensaje = "Falta el identificar de la ficha de estudio socioeconomico";
            }
           else if (obj.IdUsuario == 0)
            {
                Mensaje = "Recuerda primero asignar el  usuario para el estudio socioeconomico";
            }
            else if (string.IsNullOrEmpty(obj.regMedicoNo) || string.IsNullOrWhiteSpace(obj.regMedicoNo))
            {
                Mensaje = "El campo regMedicoNo no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.regSocialNo) || string.IsNullOrWhiteSpace(obj.regSocialNo))
            {
                Mensaje = "El campo regSocialNo no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.fechaIngreso) || string.IsNullOrWhiteSpace(obj.fechaIngreso))
            {
                Mensaje = "El campo fechaIngreso no puede estar vacío";
            }
            else if (string.IsNullOrEmpty(obj.fechaEntrevista) || string.IsNullOrWhiteSpace(obj.fechaEntrevista))
            {
                Mensaje = "El campo fechaEntrevista no puede estar vacío";
            }
            else if (string.IsNullOrEmpty(obj.tsEntrevisto) || string.IsNullOrWhiteSpace(obj.tsEntrevisto))
            {
                Mensaje = "El campo tsEntrevisto no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.evaluo) || string.IsNullOrWhiteSpace(obj.evaluo))
            {
                Mensaje = "El campo evaluo no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.escolaridad) || string.IsNullOrWhiteSpace(obj.escolaridad))
            {
                Mensaje = "El campo escolaridad no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.permanente) || string.IsNullOrWhiteSpace(obj.permanente))
            {
                Mensaje = "El campo permanente no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.temporal) || string.IsNullOrWhiteSpace(obj.temporal))
            {
                Mensaje = "El campo temporal no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.atendidoPor) || string.IsNullOrWhiteSpace(obj.atendidoPor))
            {
                Mensaje = "El campo atendidoPor no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.religion) || string.IsNullOrWhiteSpace(obj.religion))
            {
                Mensaje = "El campo religion no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.dxMedico) || string.IsNullOrWhiteSpace(obj.dxMedico))
            {
                Mensaje = "El campo dxMedico no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.servicio) || string.IsNullOrWhiteSpace(obj.servicio))
            {
                Mensaje = "El campo servicio no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.ft) || string.IsNullOrWhiteSpace(obj.ft))
            {
                Mensaje = "El campo ft no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.Pscina) || string.IsNullOrWhiteSpace(obj.Pscina))
            {
                Mensaje = "El campo Pscina no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.t_o) || string.IsNullOrWhiteSpace(obj.t_o))
            {
                Mensaje = "El campo t_o no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.tl) || string.IsNullOrWhiteSpace(obj.tl))
            {
                Mensaje = "El campo tl no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.ee) || string.IsNullOrWhiteSpace(obj.ee))
            {
                Mensaje = "El campo ee no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.escuela) || string.IsNullOrWhiteSpace(obj.escuela))
            {
                Mensaje = "El campo escuela no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.pSicol) || string.IsNullOrWhiteSpace(obj.pSicol))
            {
                Mensaje = "El campo Psicol no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.indCasa) || string.IsNullOrWhiteSpace(obj.indCasa))
            {
                Mensaje = "El campo indCasa no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.motivoSolicitud) || string.IsNullOrWhiteSpace(obj.motivoSolicitud))
            {
                Mensaje = "El campo motivoSolicitud no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.paredes) || string.IsNullOrWhiteSpace(obj.paredes))
            {
                Mensaje = "El campo paredes no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.techo) || string.IsNullOrWhiteSpace(obj.techo))
            {
                Mensaje = "El campo techo no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.pisos) || string.IsNullOrWhiteSpace(obj.pisos))
            {
                Mensaje = "El campo pisos no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.noHabitaciones) || string.IsNullOrWhiteSpace(obj.noHabitaciones))
            {
                Mensaje = "El campo noHabitaciones no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.agua) || string.IsNullOrWhiteSpace(obj.agua))
            {
                Mensaje = "El campo agua no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.luzeElectrica) || string.IsNullOrWhiteSpace(obj.luzeElectrica))
            {
                Mensaje = "El campo luzeElectrica no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.servicioSanitario) || string.IsNullOrWhiteSpace(obj.servicioSanitario))
            {
                Mensaje = "El campo servicioSanitario no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.letrina) || string.IsNullOrWhiteSpace(obj.letrina))
            {
                Mensaje = "El campo letrina no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.otros1) || string.IsNullOrWhiteSpace(obj.otros1))
            {
                Mensaje = "El campo otros1 no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.cosinaFuera) || string.IsNullOrWhiteSpace(obj.cosinaFuera))
            {
                Mensaje = "El campo cosinaFuera no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.esPropia) || string.IsNullOrWhiteSpace(obj.esPropia))
            {
                Mensaje = "El campo esPropia no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.prestada) || string.IsNullOrWhiteSpace(obj.prestada))
            {
                Mensaje = "El campo prestada no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.alquila) || string.IsNullOrWhiteSpace(obj.alquila))
            {
                Mensaje = "El campo alquila no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.otros2) || string.IsNullOrWhiteSpace(obj.otros2))
            {
                Mensaje = "El campo otros2 no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.pagoMensual) || string.IsNullOrWhiteSpace(obj.pagoMensual))
            {
                Mensaje = "El campo pagoMensual no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.diagnosticoSocial) || string.IsNullOrWhiteSpace(obj.diagnosticoSocial))
            {
                Mensaje = "El campo diagnosticoSocial no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.opinionTS) || string.IsNullOrWhiteSpace(obj.opinionTS))
            {
                Mensaje = "El campo opinionTS no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.observaciones) || string.IsNullOrWhiteSpace(obj.observaciones))
            {
                Mensaje = "El campo observaciones no puede ser vacío";
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

        public bool Editar(FichaEstudioSocioeconomico obj, out string Mensaje)
        {
            Mensaje = String.Empty;

            if (obj.IdUsuario == 0)
            {
                Mensaje = "Recuerda primero asigar el  usuario para el estudio socioeconomico";
            }
            else if (string.IsNullOrEmpty(obj.regMedicoNo) || string.IsNullOrWhiteSpace(obj.regMedicoNo))
            {
                Mensaje = "El campo regMedicoNo no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.regSocialNo) || string.IsNullOrWhiteSpace(obj.regSocialNo))
            {
                Mensaje = "El campo regSocialNo no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.fechaIngreso) || string.IsNullOrWhiteSpace(obj.fechaIngreso))
            {
                Mensaje = "El campo fechaIngreso no puede estar vacío";
            }
            else if (string.IsNullOrEmpty(obj.fechaEntrevista) || string.IsNullOrWhiteSpace(obj.fechaEntrevista))
            {
                Mensaje = "El campo fechaEntrevista no puede estar vacío";
            }
            else if (string.IsNullOrEmpty(obj.tsEntrevisto) || string.IsNullOrWhiteSpace(obj.tsEntrevisto))
            {
                Mensaje = "El campo tsEntrevisto no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.evaluo) || string.IsNullOrWhiteSpace(obj.evaluo))
            {
                Mensaje = "El campo evaluo no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.escolaridad) || string.IsNullOrWhiteSpace(obj.escolaridad))
            {
                Mensaje = "El campo escolaridad no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.permanente) || string.IsNullOrWhiteSpace(obj.permanente))
            {
                Mensaje = "El campo permanente no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.temporal) || string.IsNullOrWhiteSpace(obj.temporal))
            {
                Mensaje = "El campo temporal no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.atendidoPor) || string.IsNullOrWhiteSpace(obj.atendidoPor))
            {
                Mensaje = "El campo atendidoPor no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.religion) || string.IsNullOrWhiteSpace(obj.religion))
            {
                Mensaje = "El campo religion no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.dxMedico) || string.IsNullOrWhiteSpace(obj.dxMedico))
            {
                Mensaje = "El campo dxMedico no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.servicio) || string.IsNullOrWhiteSpace(obj.servicio))
            {
                Mensaje = "El campo servicio no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.ft) || string.IsNullOrWhiteSpace(obj.ft))
            {
                Mensaje = "El campo ft no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.Pscina) || string.IsNullOrWhiteSpace(obj.Pscina))
            {
                Mensaje = "El campo Pscina no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.t_o) || string.IsNullOrWhiteSpace(obj.t_o))
            {
                Mensaje = "El campo t_o no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.tl) || string.IsNullOrWhiteSpace(obj.tl))
            {
                Mensaje = "El campo tl no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.ee) || string.IsNullOrWhiteSpace(obj.ee))
            {
                Mensaje = "El campo ee no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.escuela) || string.IsNullOrWhiteSpace(obj.escuela))
            {
                Mensaje = "El campo escuela no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.pSicol) || string.IsNullOrWhiteSpace(obj.pSicol))
            {
                Mensaje = "El campo Psicol no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.indCasa) || string.IsNullOrWhiteSpace(obj.indCasa))
            {
                Mensaje = "El campo indCasa no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.motivoSolicitud) || string.IsNullOrWhiteSpace(obj.motivoSolicitud))
            {
                Mensaje = "El campo motivoSolicitud no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.paredes) || string.IsNullOrWhiteSpace(obj.paredes))
            {
                Mensaje = "El campo paredes no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.techo) || string.IsNullOrWhiteSpace(obj.techo))
            {
                Mensaje = "El campo techo no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.pisos) || string.IsNullOrWhiteSpace(obj.pisos))
            {
                Mensaje = "El campo pisos no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.noHabitaciones) || string.IsNullOrWhiteSpace(obj.noHabitaciones))
            {
                Mensaje = "El campo noHabitaciones no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.agua) || string.IsNullOrWhiteSpace(obj.agua))
            {
                Mensaje = "El campo agua no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.luzeElectrica) || string.IsNullOrWhiteSpace(obj.luzeElectrica))
            {
                Mensaje = "El campo luzeElectrica no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.servicioSanitario) || string.IsNullOrWhiteSpace(obj.servicioSanitario))
            {
                Mensaje = "El campo servicioSanitario no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.letrina) || string.IsNullOrWhiteSpace(obj.letrina))
            {
                Mensaje = "El campo letrina no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.otros1) || string.IsNullOrWhiteSpace(obj.otros1))
            {
                Mensaje = "El campo otros1 no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.cosinaFuera) || string.IsNullOrWhiteSpace(obj.cosinaFuera))
            {
                Mensaje = "El campo cosinaFuera no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.esPropia) || string.IsNullOrWhiteSpace(obj.esPropia))
            {
                Mensaje = "El campo esPropia no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.prestada) || string.IsNullOrWhiteSpace(obj.prestada))
            {
                Mensaje = "El campo prestada no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.alquila) || string.IsNullOrWhiteSpace(obj.alquila))
            {
                Mensaje = "El campo alquila no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.otros2) || string.IsNullOrWhiteSpace(obj.otros2))
            {
                Mensaje = "El campo otros2 no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.pagoMensual) || string.IsNullOrWhiteSpace(obj.pagoMensual))
            {
                Mensaje = "El campo pagoMensual no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.diagnosticoSocial) || string.IsNullOrWhiteSpace(obj.diagnosticoSocial))
            {
                Mensaje = "El campo diagnosticoSocial no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.opinionTS) || string.IsNullOrWhiteSpace(obj.opinionTS))
            {
                Mensaje = "El campo opinionTS no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.observaciones) || string.IsNullOrWhiteSpace(obj.observaciones))
            {
                Mensaje = "El campo observaciones no puede ser vacío";
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
