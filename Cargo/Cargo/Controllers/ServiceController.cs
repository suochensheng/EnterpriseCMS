using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Cargo.Controllers
{
    public class ServiceController : Controller
    {
        //
        // GET: /Service/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Process()
        {
            return PartialView("_Process");
        }
        public ActionResult TransportLines()
        {
            Cargo.App_DataClass.TransportLines m = Cargo.App_DataClass.TransportLines.GetData();
            return View("TransportLines",m);
        }
        public ActionResult ContactUs()
        {
            return View("ContactUs");
        }
    }
}
