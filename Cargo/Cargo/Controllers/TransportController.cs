using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Cargo.Controllers
{
    public class TransportController : Controller
    {
        //
        // GET: /Transport/

        public ActionResult Index()
        {
            Cargo.App_DataClass.Strength m = Cargo.App_DataClass.Strength.GetData();
            return View(m);
        }

        public ActionResult Strength()
        {
            Cargo.App_DataClass.Strength m = Cargo.App_DataClass.Strength.GetData();
            return PartialView("_Strength",m);
        }
        public ActionResult BargeScale()
        {
            return PartialView("_BargeScale");
        }
        public ActionResult LDT()
        {
            return PartialView("_LDT");
        }
    }
}
