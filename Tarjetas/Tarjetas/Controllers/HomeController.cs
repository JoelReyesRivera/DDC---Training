using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tarjetas.Models;

namespace Tarjetas.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext db = new AppDbContext();

        public ActionResult Index()
        {
            var institucions = db.Institucion.ToList<Institucion>();
            ViewBag.institucions = institucions;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}