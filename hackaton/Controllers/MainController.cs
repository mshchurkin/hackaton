using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hackaton.Controllers
{
    public class MainController : Controller
    {
        //
        // GET: /Main/
        public ActionResult Main()
        {
            return View();
        }

        public JsonResult GetData()
        {
            List<Cargo> cargos = new List<Cargo>();
            cargos.Add(new Cargo()
            {
                Id = 1,
                Name="Груз 1",
                GeoLat=58.014660,
                GeoLong =56.281562
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