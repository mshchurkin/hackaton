using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hackaton.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            ViewBag.Message = "check";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public JsonResult GetData()
        {
            List<Cargo> cargos = new List<Cargo>();
            cargos.Add(new Cargo()
            {
                Id = 1,
                Name = "Груз 1",
                GeoLat = 58.014660,
                GeoLong = 56.281562
            });
            cargos.Add(new Cargo()
            {
                Id = 2,
                Name = "Груз 2",
                GeoLat = 58.013114,
                GeoLong = 56.300702
            });
            return Json(cargos, JsonRequestBehavior.AllowGet);
        }
    }
}