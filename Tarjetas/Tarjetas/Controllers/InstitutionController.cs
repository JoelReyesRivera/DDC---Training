using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tarjetas.Models;

namespace Tarjetas.Controllers
{
    public class InstitutionController : Controller
    {
        private AppDbContext db = new AppDbContext();

        public ActionResult Index()
        {
            ViewBag.institucions = new List<Institucion>();
            ViewBag.institucion = new Institucion();
            return View();
        }

        [HttpPost]
        public JsonResult GetInstitution(String institucion)
        {
            var institucions = db.Institucion.Where<Institucion>(i => i.Nombre == institucion.ToUpper()).ToList();
            return Json(institucions);
        }

        [HttpPost]
        public JsonResult AddInstitution(string nombre, string identificador, string usuario)
        {
            var jsonResult = Json(new { existeError = false, resultMessage = "AGREGADO CORRECTAMENTE" });
            var institucion = new Institucion(nombre.ToUpper(), identificador, usuario);
            try
            {
                db.Institucion.Add(institucion);
                db.SaveChanges();
            }
            catch ( Exception e)
            {
                jsonResult = Json(new { existeError = true, excepcion = e.Message, resultMessage = "NO SE AGREGO CORRECTAMENTE" });
            }

            return jsonResult;
        }
    }
}