using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaNegocio;
namespace CapaFichaUsuario.Controllers
{

    [Authorize]
    public class EstudioController : Controller
    {
        // GET: Estudio
        public ActionResult Estudio()
        {
            if (Session["Usuario"] == null || ((Acceso)Session["Usuario"]).NombrPuesto != "Trabajadora Social")
            {
                ViewBag.error = "Lo siento tu no tienes acceso a este modulo";
                return RedirectToAction("Index", "Login"); // Redirigir a la página de inicio de sesión
            }
            return View();
        }
        // GET: HistorialFichasEstudio
        public ActionResult HistorialFichasEstudio()
        {
            if (Session["Usuario"] == null || ((Acceso)Session["Usuario"]).NombrPuesto != "Trabajadora Social")
            {
                ViewBag.error = "Lo siento tu no tienes acceso a este modulo";
                return RedirectToAction("Index", "Login"); // Redirigir a la página de inicio de sesión
            }
            return View();
        }


        [HttpGet]
        public JsonResult ListarHistorialEstudio()
        {
            List<HistorialFichasEstudio> oLista = new List<HistorialFichasEstudio>();

            oLista = new CN_FichaEstudioSocioeconomico().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }



        [HttpGet]
        public JsonResult VistaFichaEstudio(int IdFichaEstudioEconomico)
        {
            BuscarFichaEstudio objeto = new CN_FichaEstudioSocioeconomico().VerFichaEstudio(IdFichaEstudioEconomico);
            return Json(new { resultado = objeto }, JsonRequestBehavior.AllowGet);

        }


        [HttpPost]
        public JsonResult GuardarFichaEstudiSocioEconomico(FichaEstudioSocioeconomico objeto)
        {
            object resultado;
            string mensaje = string.Empty;



            resultado = new CN_FichaEstudioSocioeconomico().Registrar(objeto, out mensaje);


            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);


        }




        [HttpPost]
        public JsonResult ActualizarFichaEstudioSociEconomico(FichaEstudioSocioeconomico objeto)
        {
            object resultado;
            string mensaje = string.Empty;


            resultado = new CN_FichaEstudioSocioeconomico().Editar(objeto, out mensaje);



            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);


        }





        [HttpPost]
        public JsonResult EliminarEstudioSocioEconomico(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_FichaEstudioSocioeconomico().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult GuardarGrupoFamiliar(GrupoFamiliar objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdGrupoFamiliar == 0)
            {

                resultado = new CN_GrupoFamiliar().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_GrupoFamiliar().Editar(objeto, out mensaje);

            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);


        }

        [HttpPost]
        public JsonResult EliminarGrupoFamiñiar(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_GrupoFamiliar().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult ListarGrpoFamiliar(int IdFichaEstudioEconomico)
        {
            List<GrupoFamiliar> oLista = new List<GrupoFamiliar>();

            oLista = new CN_GrupoFamiliar().Listar2(IdFichaEstudioEconomico);

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }








    }
}