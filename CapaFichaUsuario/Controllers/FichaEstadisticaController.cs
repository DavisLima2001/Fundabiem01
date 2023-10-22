using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iTextSharp;

using CapaEntidad;
using CapaNegocio;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace CapaFichaUsuario.Controllers
{
    [Authorize]
    public class FichaEstadisticaController : Controller
    {
   
        public ActionResult FichaEstadisticaMedica()
        {

            if (Session["Usuario"] == null || ((Acceso)Session["Usuario"]).NombrPuesto != "Medico")
            {
                ViewBag.error = "Lo siento tu no tienes acceso a este modulo";
                return RedirectToAction("Index", "Login"); // Redirigir a la página de inicio de sesión
            }
            return View();
        }

     
        public ActionResult HistorialFichasEstadisticaMedica()
        {
            if (Session["Usuario"] == null || ((Acceso)Session["Usuario"]).NombrPuesto != "Medico")
            {
                ViewBag.error = "Lo siento tu no tienes acceso a este modulo";
                return RedirectToAction("Index", "Login"); // Redirigir a la página de inicio de sesión
            }
            return View();
        }
        
        public ActionResult ReporteEstadistica()
        {
            if (Session["Usuario"] == null || ((Acceso)Session["Usuario"]).NombrPuesto != "Medico")
            {
                ViewBag.error = "Lo siento tu no tienes acceso a este modulo";
                return RedirectToAction("Index", "Login"); // Redirigir a la página de inicio de sesión
            }
            return View();
        }
        [HttpGet]
        public ActionResult CambiarEstilo()
        {
            // Lógica para cambiar la hoja de estilo (por ejemplo, establecer un valor en una sesión)
            Session["Site.css"] = "Site2.css";

            return RedirectToAction("ReporteEstadistica");
        }

        [HttpGet]
        public JsonResult ListarEstadisticaDiaria()
        {
            List<Estadistica> oLista = new List<Estadistica>();

            oLista = new CN_Estadisctica().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult GuardarTablaEstadistica(TablaEstadistica objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdTabEstadistica == 0)
            {

                resultado = new CN_TablaEstadisctica().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_TablaEstadisctica().Editar(objeto, out mensaje);

            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);


        }
        [HttpPost]
        public JsonResult EliminarTablaEstadistica(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_TablaEstadisctica().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }




        [HttpGet]
        public JsonResult VistaEstadisctica(string FechaRegistro)
        {
            Estadistica objeto = new CN_Estadisctica().VerEstadisctica(FechaRegistro);
            return Json(new { resultado = objeto }, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public JsonResult ListarTablaEstadistica(string FechaRegistro)
        {
            List<BuscarTablaEstadistica> oLista = new List<BuscarTablaEstadistica>();

            oLista = new CN_TablaEstadisctica().Listar2(FechaRegistro);

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult ListarTablaEstadistica3(string FechaInicio, string FechaFin)
        {
            List<BuscarTablaEstadistica> oLista = new List<BuscarTablaEstadistica>();

            oLista = new CN_TablaEstadisctica().Listar3(FechaInicio, FechaFin);

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult GuardarEstadistica(Estadistica objeto)
        {
            object resultado;
            string mensaje = string.Empty;



            resultado = new CN_Estadisctica().Registrar(objeto, out mensaje);


            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);


        }




        [HttpPost]
        public JsonResult ActualizarEstastica(Estadistica objeto)
        {
            object resultado;
            string mensaje = string.Empty;


            resultado = new CN_Estadisctica().Editar(objeto, out mensaje);



            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);


        }
        [HttpPost]
        public JsonResult EliminarEstadistica(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Estadisctica().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }



        [HttpGet]
        public ActionResult GenerarPDF(string FechaInicio, string FechaFin)
        {
            List<BuscarTablaEstadistica> oLista = new CN_TablaEstadisctica().Listar3(FechaInicio, FechaFin);

            byte[] pdfBytes = CrearPDF(oLista);

            // Devolver el PDF como un archivo descargable
            return File(pdfBytes, "application/pdf", "Reporte.pdf");
        }

        public byte[] CrearPDF(List<BuscarTablaEstadistica> datos)
        {
            using (var memoryStream = new MemoryStream())
            {
                var writer = new PdfWriter(memoryStream);
                var pdf = new PdfDocument(writer);
                var document = new Document(pdf);

                // Añadir contenido al PDF aquí
                document.Add(new Paragraph("Reporte Estadístico"));

                // Iterar sobre tus datos y agregarlos al PDF
                foreach (var item in datos)
                {
                    document.Add(new Paragraph($"{item.FechaRegistro}, {item.Nombre}, ...")); // Ajusta las propiedades según tu modelo
                }

                document.Close();

                return memoryStream.ToArray();
            }
        }
    }
}