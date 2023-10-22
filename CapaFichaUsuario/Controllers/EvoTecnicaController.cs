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
    public class EvoTecnicaController : Controller
    {
        // GET: EvoTecnica
        public ActionResult EvolucionTecnica()
        {
            if (Session["Usuario"] == null || ((Acceso)Session["Usuario"]).NombrPuesto != "Terapista")
            {
                ViewBag.error = "Lo siento tu no tienes acceso a este modulo";
                return RedirectToAction("Index", "Login"); // Redirigir a la página de inicio de sesión
            }
            return View();
        }
        public ActionResult HistorialEvoTecnica()
        {
            if (Session["Usuario"] == null || ((Acceso)Session["Usuario"]).NombrPuesto != "Terapista")
            {
                ViewBag.error = "Lo siento tu no tienes acceso a este modulo";
                return RedirectToAction("Index", "Login"); // Redirigir a la página de inicio de sesión
            }
            return View();
        }
        public ActionResult ListadoHistorialClinica()
        {
            if (Session["Usuario"] == null || ((Acceso)Session["Usuario"]).NombrPuesto != "Terapista")
            {
                ViewBag.error = "Lo siento tu no tienes acceso a este modulo";
                return RedirectToAction("Index", "Login"); // Redirigir a la página de inicio de sesión
            }
            return View();
        }


        [HttpGet]
        public JsonResult ListarFichaEvolucionTecnica()
        {
            List<BuscarFichaEvolucionTecnica> oLista = new List<BuscarFichaEvolucionTecnica>();

            oLista = new CN_FichaEvolucionTecnica().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);

        }


        [HttpGet]
        public JsonResult ListarTablaEvolucionTecnica(int IdFichaEvolucionTecnica)
        {
            List<TablaEvolucionTecnica> oLista = new List<TablaEvolucionTecnica>();

            oLista = new CN_TablaEvolucionTecnica().Listar2(IdFichaEvolucionTecnica);

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarTablaEvolucionTecnica(TablaEvolucionTecnica objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdTablaEvolucionTecnica == 0)
            {

                resultado = new CN_TablaEvolucionTecnica().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_TablaEvolucionTecnica().Editar(objeto, out mensaje);

            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);


        }


        [HttpPost]
        public JsonResult EliminarTablaEvolcucionTecnica(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_TablaEvolucionTecnica().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }








        [HttpGet]
        public JsonResult VistaFichaEvolucionTecnica(int IdFichaEvolucionTecnica)
        {
            BuscarFichaEvolucionTecnica objeto = new CN_FichaEvolucionTecnica().VerFichaEvolucionTecnica(IdFichaEvolucionTecnica);
            return Json(new { resultado = objeto }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GuardarFichaEvolucionTecnica(FichaEvolucionTenica objeto)
        {
            object resultado;
            string mensaje = string.Empty;
            resultado = new CN_FichaEvolucionTecnica().Registrar(objeto, out mensaje);
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Actualizar(FichaEvolucionTenica objeto)
        {
            object resultado;
            string mensaje = string.Empty;
            resultado = new CN_FichaEvolucionTecnica().Editar(objeto, out mensaje);
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult EliminarFichaEvolucionTecnica(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;
            respuesta = new CN_FichaEvolucionTecnica().Eliminar(id, out mensaje);
            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}