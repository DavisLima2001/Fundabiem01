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
    public class EvoMedicaController : Controller
    {
        // GET: EvoMedica
        public ActionResult EvolucionMedica()
        {
            if (Session["Usuario"] == null || ((Acceso)Session["Usuario"]).NombrPuesto != "Medico")
            {
                ViewBag.error = "Lo siento tu no tienes acceso a este modulo";
                return RedirectToAction("Index", "Login"); // Redirigir a la página de inicio de sesión
            }

            return View();
        }

        public ActionResult HistorialFichaEvoMedica()
        {
            if (Session["Usuario"] == null || ((Acceso)Session["Usuario"]).NombrPuesto != "Medico")
            {
                ViewBag.error = "Lo siento tu no tienes acceso a este modulo";
                return RedirectToAction("Index", "Login"); // Redirigir a la página de inicio de sesión
            }
            return View();
        }



        [HttpGet]
        public JsonResult ListarFichaEvolucionMedica()
        {
            List<BuscarFichaEvolucionMedica2> oLista = new List<BuscarFichaEvolucionMedica2>();

            oLista = new CN_FichaEvolucionMedica().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public JsonResult ListarTablaEvolucionMedica()
        {
            List<TablaEvolucionMedica> oLista = new List<TablaEvolucionMedica>();

            oLista = new CN_TablaEvolucionMedica().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult ListarTablaEvolucionMedica2(int IdFichaEvolucionMedica)
        {
            List<TablaEvolucionMedica> oLista = new List<TablaEvolucionMedica>();

            oLista = new CN_TablaEvolucionMedica().Listar2(IdFichaEvolucionMedica);

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarTablaEvolucionMedida(TablaEvolucionMedica objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdTablaEvolucionMedica == 0)
            {

                resultado = new CN_TablaEvolucionMedica().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_TablaEvolucionMedica().Editar(objeto, out mensaje);

            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);


        }

        [HttpPost]
        public JsonResult EliminarTablaEvolcucionMedica (int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_TablaEvolucionMedica().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }



        [HttpGet]
        public JsonResult VistaFichaEvolucionMedica2(int IdFichaEvolucionMedica)
        {
            BuscarFichaEvolucionMedica2 objeto = new CN_FichaEvolucionMedica().VerFichaEvolucionMedica2(IdFichaEvolucionMedica);
            return Json(new { resultado = objeto }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public JsonResult VistaFichaEvolucionMedica(int IdHistorialClinica )
        {
            BuscarFichaEvolucionMedica objeto = new CN_FichaEvolucionMedica().VerFichaEvolucionMedica(IdHistorialClinica);
            return Json(new { resultado = objeto }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult GuardarFichaEvolucionMedica( FichaEvolucionMedica objeto)
        {
            object resultado;
            string mensaje = string.Empty;



            resultado = new CN_FichaEvolucionMedica().Registrar(objeto, out mensaje);


            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);


        }


        [HttpPost]
        public JsonResult Actualizar(FichaEvolucionMedica objeto)
        {
            object resultado;
            string mensaje = string.Empty;


            resultado = new CN_FichaEvolucionMedica().Editar(objeto, out mensaje);



            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);


        }

        [HttpPost]
        public JsonResult EliminarFichaEvolucionMedica(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_FichaEvolucionMedica().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

    }
}