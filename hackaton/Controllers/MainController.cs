using hackaton.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hackaton.Controllers
{
    public class MainController : Controller
    {
        private DataManager _DataManager;

        public MainController(DataManager _DM)
        {
            _DataManager = _DM;

        }
        //
        // GET: /Main/
        public ActionResult Main()
        {
            return View();
        }

        public JsonResult GetData(int _UserId)
        {
            IEnumerable<Cargo> c= _DataManager.CR.Cargos(_UserId);
            List<Cargo> cargos = c.ToList<Cargo>();
            return Json(cargos, JsonRequestBehavior.AllowGet);
        }
	}
}