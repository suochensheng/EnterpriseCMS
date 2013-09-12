using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Service.Security;
using Cargo.App_DataClass;
using ApplicationUtility;
using System.IO;

namespace Cargo.Areas.Admin.Controllers
{
    [AdminAuthorize]
    public class TransportAdminController : BaseController
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TransportLinesEdit()
        {
            TransportLines m = TransportLines.GetData();

            return View(m);
        }

        public ActionResult TransportLinesEditSubmit(TransportLines m)
        {
            XMLHelper.SerializaXML<TransportLines>(XMLPath.XMLPath_TransportLines, m);
            base.SuccessNotification("Submit successed!");
            return RedirectToAction("TransportLinesEdit", "TransportAdmin", new { Area = "Admin" });
        }

        public ActionResult ContactEdit()
        {
            ContactInfo m = ContactInfo.GetData();

            return View(m);
        }

        public ActionResult ContactEditSubmit(ContactInfo m)
        {
            XMLHelper.SerializaXML<ContactInfo>(XMLPath.XMLPath_Contact, m);
            base.SuccessNotification("Submit successed!");
            return RedirectToAction("ContactEdit", "TransportAdmin", new { Area = "Admin" });
        }

        public ActionResult StrengthEdit()
        {
            Strength m = Strength.GetData();

            return View(m);
        }

        public ActionResult StrengthEditSubmit(Strength m)
        {
            int n = 0;
            foreach (string upload in Request.Files)
            {
                n++;
                if (!HasFile(Request.Files[upload]))
                    continue;

                string path = AppDomain.CurrentDomain.BaseDirectory + "Images\\strength\\";
                
                //var t= Request.Files["fileupload_1"];
                //string tn=t==null?"":t.FileName;

                string filename = Path.GetFileName(Request.Files[upload].FileName);
                string imageNewFullPath = Path.Combine(path,"block"+ n + ".jpg");
                Request.Files[upload].SaveAs(imageNewFullPath);//upload image

                if (n == 1 || n == 6)
                {
                    ImageHelper.Resize(imageNewFullPath, 720, 240);//resize image
                }
                else
                {
                    ImageHelper.Resize(imageNewFullPath, 356, 240);//resize image
                }

            }

            XMLHelper.SerializaXML<Strength>(XMLPath.XMLPath_Strength, m);
            base.SuccessNotification("Submit successed!");
            return RedirectToAction("StrengthEdit", "TransportAdmin", new { Area = "Admin" });
        }
        public bool HasFile(HttpPostedFileBase file)
        {
            return (file != null && file.ContentLength > 0) ? true : false;
        }
    }
}
