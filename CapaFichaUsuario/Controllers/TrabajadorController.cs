using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapaFichaUsuario.Controllers
{
    [Authorize]
    public class TrabajadorController : Controller
    {
    
        // GET: Trabajador
        public ActionResult Index()
        {
            return View();
        }
    }
}