using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tarjetas.Models;

namespace Tarjetas.Controllers
{
    public class AppController : Controller
    {
        private AppDbContext db = new AppDbContext();

        public ActionResult Index()
        {
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

        [HttpPost]
        public JsonResult GetTarjeta(String numero)
        {
            var tarjetas = db.tarjeta.Where<Tarjeta>(i => i.Numero == numero).ToList();
            return Json(tarjetas);
        }

        public JsonResult AddTarjeta(string numero, string institucion, string usuario)
        {
            var jsonResult = Json(new { existeError = false, resultMessage = "AGREGADO CORRECTAMENTE" });
            try
            {
                int institucionInteger = Int32.Parse(institucion);
                var tarjeta = new Tarjeta(numero, institucionInteger, usuario);
                db.tarjeta.Add(tarjeta);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                jsonResult = Json(new { existeError = true, excepcion = e.Message, resultMessage = "NO SE AGREGO CORRECTAMENTE" });
            }

            return jsonResult;
        }

        public JsonResult DeleteInstitucion(String id)
        {
            var jsonResult = Json(new { existeError = false, resultMessage = "ELIMINADO CORRECTAMENTE" });
            try
            {
                int Clave = Int32.Parse(id);
                Institucion institucion = db.Institucion.Find(Clave);
                db.Institucion.Remove(institucion);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                jsonResult = Json(new { existeError = true, excepcion = e.Message, resultMessage = "NO SE ELIMINO CORRECTAMENTE" });
            }

            return jsonResult;
        }

        public JsonResult DeleteTarjeta(String id)
        {
            var jsonResult = Json(new { existeError = false, resultMessage = "ELIMINADO CORRECTAMENTE" });
            try
            {
                int Clave = Int32.Parse(id);
                Tarjeta tarjeta = db.tarjeta.Find(Clave);
                db.tarjeta.Remove(tarjeta);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                jsonResult = Json(new { existeError = true, excepcion = e.Message, resultMessage = "NO SE ELIMINO CORRECTAMENTE" });
            }

            return jsonResult;
        }
    }
}