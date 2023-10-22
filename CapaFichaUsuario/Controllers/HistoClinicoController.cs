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
    public class HistoClinicoController : Controller
    {
        // GET: HistoClinico
        public ActionResult FichaHistorialClinico()
        {
            if (Session["Usuario"] == null || ((Acceso)Session["Usuario"]).NombrPuesto != "Medico")
            {
                ViewBag.error = "Lo siento tu no tienes acceso a este modulo";
                return RedirectToAction("Index", "Login"); // Redirigir a la página de inicio de sesión
            }
            return View();
        }
        // GET: HistoClinico
        public ActionResult HistorialClinica()
        {
            if (Session["Usuario"] == null || ((Acceso)Session["Usuario"]).NombrPuesto != "Medico")
            {
                ViewBag.error = "Lo siento tu no tienes acceso a este modulo";
                return RedirectToAction("Index", "Login"); // Redirigir a la página de inicio de sesión
            }
            return View();
        }



        [HttpGet]
        public JsonResult ListarHistorialClinicas()
        {
            List<HistorialFichasClinica> oLista = new List<HistorialFichasClinica>();

            oLista = new CN_FichaHistorialClinica().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult VistaFichaHistorial(int IdHistorialClinica)
        {
            BuscarFiHistorialClinica objeto = new CN_BuscarFiHistorialMedica().VerFichaHistorialMedica( IdHistorialClinica);
            return Json(new { resultado = objeto }, JsonRequestBehavior.AllowGet);

        }


        [HttpPost]
        public JsonResult GuardarFichaHistorialClinica(FichaHistorialClinica objeto)
        {
            object resultado;
            string mensaje = string.Empty;

        

                resultado = new CN_FichaHistorialClinica().Registrar(objeto, out mensaje);
   
           
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);


        }




        [HttpPost]
        public JsonResult Actualizar(FichaHistorialClinica objeto)
        {
            object resultado;
            string mensaje = string.Empty;


            resultado = new CN_FichaHistorialClinica().Editar(objeto, out mensaje);



            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);


        }
        [HttpPost]
        public JsonResult ActualizarDiagnostivos(FichaHistorialClinica objeto)
        {
            object resultado;
            string mensaje = string.Empty;


            resultado = new CN_FichaHistorialClinica().EditarDiagnisticos(objeto, out mensaje);



            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);


        }


        [HttpGet]
        public JsonResult ListarTratamiento()
        {
            List<Tratamiento> oLista = new List<Tratamiento>();

            oLista = new CN_Tratamiento().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult ListarTratamiento2(int IdHistorialClinica)
        {
            List<Tratamiento> oLista = new List<Tratamiento>();

            oLista = new CN_Tratamiento().Listar2(IdHistorialClinica);

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarTratamiento(Tratamiento objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdTablaTratamiento == 0)
            {

                resultado = new CN_Tratamiento().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_Tratamiento().Editar(objeto, out mensaje);

            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);


        }

        [HttpPost]
        public JsonResult EliminarTratamiento(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Tratamiento().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult EliminarHitorialClinica(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_FichaHistorialClinica().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }



    }
}