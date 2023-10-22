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

    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string email, String clave)
        {
            ActionResult resultadoRedireccion = View();
            Acceso oUsuario = new Acceso();

            oUsuario = new CN_Acceso().Listar().Where(u => u.Correo == email && u.Contraseña == CN_Recursos.ConvertirSha256(clave)).FirstOrDefault();



            if (oUsuario == null)
            {
                ViewBag.error = "Correo o contraseña incorrecta, Intentelo de nuevo";
                resultadoRedireccion = View();
            }
            else if (oUsuario.NombrPuesto== "Secretaria" && oUsuario.Activo==true)
            {
                FormsAuthentication.SetAuthCookie(oUsuario.Correo, false);
                Session["Usuario"] = oUsuario;
                ViewBag.error = null;
                 resultadoRedireccion = RedirectToAction("Ficha", "FichaUsuario");
            }
            else if (oUsuario.NombrPuesto == "Trabajadora Social" && oUsuario.Activo == true)
            {
                FormsAuthentication.SetAuthCookie(oUsuario.Correo, false);
                Session["Usuario"] = oUsuario;
                ViewBag.error = null;
                resultadoRedireccion = RedirectToAction("Estudio", "Estudio");
            }
            else if (oUsuario.NombrPuesto == "Medico" && oUsuario.Activo == true)
            {
                FormsAuthentication.SetAuthCookie(oUsuario.Correo, false);
                Session["Usuario"] = oUsuario;
                ViewBag.error = null;
                resultadoRedireccion = RedirectToAction("FichaHistorialClinico", "HistoClinico");
            }
           
            else if (oUsuario.NombrPuesto == "Terapista" && oUsuario.Activo == true)
            {
                FormsAuthentication.SetAuthCookie(oUsuario.Correo, false);
                Session["Usuario"] = oUsuario;
                ViewBag.error = null;
                resultadoRedireccion = RedirectToAction("EvolucionTecnica", "EvoTecnica");
            }
            else if (oUsuario.NombrPuesto == "Admin" && oUsuario.Activo == true)
            {
                FormsAuthentication.SetAuthCookie(oUsuario.Correo, false);
                Session["Usuario"] = oUsuario;
                ViewBag.error = null;
                resultadoRedireccion = RedirectToAction("Accesos", "Admin");
            }
            else if (oUsuario.Activo == false)
            {
                ViewBag.error = "Tu correo esta inactivo";
                resultadoRedireccion = View();
            }
            else
            {
                ViewBag.error = "Acceso denegado, no tienes acceso a este modulo";
                resultadoRedireccion = View();

            }

            return resultadoRedireccion;
        }


        public ActionResult Cerrar_Sesion()
        {

            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");

        }


    }
}