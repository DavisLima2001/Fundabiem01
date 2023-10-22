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
    public class FichaUsuarioController : Controller
    {
        // GET: FichaUsuario
        public ActionResult Ficha()
        {
            if (Session["Usuario"] == null || ((Acceso)Session["Usuario"]).NombrPuesto != "Secretaria")
            {
                ViewBag.error = "Lo siento tu no tienes acceso a este modulo";
                return RedirectToAction("Index", "Login"); // Redirigir a la página de inicio de sesión
            }
            return View();
        }
        public ActionResult Estudio()
        {
            return View();
        }
        public ActionResult HistorialClinico()
        {
            return View();
        }
        public ActionResult EvolucionTecnica()
        {
            return View();
        }
        public ActionResult EvolucionMedica()
        {
            return View();
        }
        public ActionResult RegistroHistorial()
        {

            if (Session["Usuario"] == null || ((Acceso)Session["Usuario"]).NombrPuesto != "Secretaria")
            {
                ViewBag.error = "Lo siento tu no tienes acceso a este modulo";
                return RedirectToAction("Index", "Login"); // Redirigir a la página de inicio de sesión
            }
            return View();
        }
        [HttpGet]
        public JsonResult VistaUsuario(string PrimerApellido,string PrimerNombre)
        {
           
            BuscarUsuario objeto = new CN_BuscarUsuario().VerUsuario(PrimerApellido, PrimerNombre);
            if (objeto.IdUsuario != 0)
            {
                return Json(new { resultado = objeto }, JsonRequestBehavior.AllowGet);
               }
            else
            {
                return Json(null, JsonRequestBehavior.AllowGet);
                }

            }

        [HttpGet]
        public JsonResult ListarUsuarios()
        {
            List<Usuario> oLista = new List<Usuario>();

            oLista = new CN_USUARIO().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult GuardarUsuarios(Usuario objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdUsuario == 0)
            {

                resultado = new CN_USUARIO().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_USUARIO().Editar(objeto, out mensaje);

            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);


        }



        [HttpPost]
        public JsonResult Actualizar(Usuario objeto)
        {
            object resultado;
            string mensaje = string.Empty;

      
                resultado = new CN_USUARIO().Editar(objeto, out mensaje);

            

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);


        }

        [HttpPost]
        public JsonResult GuardarUsuarios2(Usuario objeto)
        {
            object resultado;
            string mensaje = string.Empty;

          

                resultado = new CN_USUARIO().Registrar(objeto, out mensaje);
            
           

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);


        }

        [HttpPost]
        public JsonResult EliminarUsuario(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_USUARIO().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }



    }
}