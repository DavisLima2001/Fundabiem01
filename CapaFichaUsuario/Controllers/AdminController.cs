using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CapaEntidad;
using CapaNegocio;

namespace CapaFichaUsuario.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Puestos()
        {
            if (Session["Usuario"] == null || ((Acceso)Session["Usuario"]).NombrPuesto != "Admin")
            {
                ViewBag.error = "Lo siento tu no tienes acceso a este modulo";
                return RedirectToAction("Index", "Login"); // Redirigir a la página de inicio de sesión
            }
            return View();
        }
        public ActionResult Empleados()
        {
            if (Session["Usuario"] == null || ((Acceso)Session["Usuario"]).NombrPuesto != "Admin")
            {
                ViewBag.error = "Lo siento tu no tienes acceso a este modulo";
                return RedirectToAction("Index", "Login"); // Redirigir a la página de inicio de sesión
            }
            return View();
        }
        public ActionResult Accesos()
        {

            // Verificar la existencia de la sesión y el rol del usuario
            if (Session["Usuario"] == null || ((Acceso)Session["Usuario"]).NombrPuesto != "Admin")
            {
                ViewBag.error = "Lo siento tu no tienes acceso a este modulo";
                return RedirectToAction("Index", "Login"); // Redirigir a la página de inicio de sesión
            }
            return View();
        }

        
        //accesos


        [HttpGet]
        public JsonResult ListarAccesos()
        {
            List<Acceso> oLista = new List<Acceso>();

            oLista = new CN_Acceso().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult GuardarAcceso(Acceso objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdAcceso == 0)
            {

                resultado = new CN_Acceso().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_Acceso().Editar(objeto, out mensaje);

            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);


        }

        [HttpPost]
        public JsonResult EliminarAcceso(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Acceso().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }


        //Empleados

        [HttpGet]
        public JsonResult ListarEmpleados()
        {
            List<Empleado> oLista = new List<Empleado>();

            oLista = new CN_Empleado().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult GuardarEmpleado(Empleado objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdEmpleado == 0)
            {

                resultado = new CN_Empleado().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_Empleado().Editar(objeto, out mensaje);

            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);


        }
        [HttpPost]
        public JsonResult EliminarEmpleado(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Empleado().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }


        //puestos para el empleado

        [HttpGet]
        public JsonResult ListarPuestos()
        {
            List<Puesto> oLista = new List<Puesto>();

            oLista = new CN_Puesto().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult GuardarPuesto(Puesto objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdPuesto == 0)
            {

                resultado = new CN_Puesto().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_Puesto().Editar(objeto, out mensaje);

            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);


        }
        [HttpPost]
        public JsonResult EliminarPuesto(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Puesto().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }


    }
}