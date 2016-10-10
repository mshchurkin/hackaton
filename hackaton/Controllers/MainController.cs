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
        private static int _UserId = 1;
        private DataManager _DataManager=new DataManager();

        public MainController(/*DataManager _DM*/)
        {
            //_DataManager = _DM;

        }
        //
        // GET: /Main/
        public ActionResult Main(/*int _UserId*/)
        {
            //this._UserId = _UserId;
            return View();
        }

        public JsonResult GetData()
        {
            IEnumerable<Cargo> c = _DataManager.CR.Cargos(_UserId);
            List<Cargo> cargos = c.ToList<Cargo>();
            return Json(cargos, JsonRequestBehavior.AllowGet);
        }
	}
}