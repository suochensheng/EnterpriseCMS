using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cargo.App_DataClass;
using ApplicationUtility;
using System.IO;
using Cargo.Models;
using Web.Service.Customers;
using Web.Service.Authentication;
using Web.Service.Security;

namespace Cargo.Areas.Admin.Controllers
{
   
    public class HomeAdminController : BaseController
    {
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(string returnUrl)
        {
            var model = new LoginModel();
           // model.UsernamesEnabled = false;//_customerSettings.UsernamesEnabled;
            model.DisplayCaptcha = false;//_captchaSettings.Enabled && _captchaSettings.ShowOnLoginPage;
            model.ReturnUrl = returnUrl;
            return View(model);
        }

      
        [HttpPost]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(returnUrl))
                {
                    model.ReturnUrl = returnUrl;
                }
                else
                {
                    returnUrl = model.ReturnUrl;
                }
                if (_customerRegService.ValidateCustomer(model.Email, model.Password))
                {
                    var customer =_customerService.GetCustomerByEmail(model.Email);

                    //sign in new customer
                    _authenticationService.SignIn(customer, model.RememberMe);
                    string s = string.Format("Login sucessed ", customer.Username);
                    base.SuccessNotification(s);
                    if (!String.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);
                    else
                        return RedirectToAction("Index", "HomeAdmin", new {Area="Admin" });
                }
                else
                {
                    ModelState.AddModelError("","Account.Login.WrongCredentials");
                }
            }
            
            return View(model);
        }

        public ActionResult Logout()
        {
            _authenticationService.SignOut();
            return RedirectToAction("Login", "HomeAdmin", new { Area = "Admin", returnUrl="" });
        }

        [AdminAuthorize]
        public ActionResult HomeImageSliderEdit()
        {
            HomeImageSlider m = HomeImageSlider.GetData();

            return View(m);
        }

        [AdminAuthorize]
        public ActionResult HomeImageSliderEditSubmit(HomeImageSlider m)
        {
            int n = 0;
            foreach (string upload in Request.Files)
            {
                n++;
                if (!HasFile(Request.Files[upload]))
                    continue;

                string path = AppDomain.CurrentDomain.BaseDirectory + "Content\\wowslider\\data1\\images\\";
                string tooltipspath = AppDomain.CurrentDomain.BaseDirectory + "Content\\wowslider\\data1\\tooltips\\";

                string filename = Path.GetFileName(Request.Files[upload].FileName);
                string imageNewFullPath = Path.Combine(path, n + ".jpg");
                Request.Files[upload].SaveAs(imageNewFullPath);//upload image

                ImageHelper.Resize(imageNewFullPath, 1000, 400);//resize image
                ImageHelper.Resize(imageNewFullPath, 100, 100, tooltipspath);//resize thumbnail.
            }

            XMLHelper.SerializaXML<HomeImageSlider>(XMLPath.XMLPath_HomeImageSlider, m);
            base.SuccessNotification("Submit successed!");
            return RedirectToAction("HomeImageSliderEdit", "HomeAdmin", new { Area = "Admin" });
        }

        public bool HasFile(HttpPostedFileBase file)
        {
            return (file != null && file.ContentLength > 0) ? true : false;
        }

        [AdminAuthorize]
        public ActionResult HomeBlock2Edit()
        {
            HomeBloks2 m = HomeBloks2.GetData();

            return View(m);
        }

        [AdminAuthorize]
        public ActionResult HomeBlock2EditSubmit(HomeBloks2 m)
        {
           
            XMLHelper.SerializaXML<HomeBloks2>(XMLPath.XMLPath_HomeBlock2, m);
            base.SuccessNotification("Submit successed!");
            return RedirectToAction("HomeBlock2Edit", "HomeAdmin", new { Area = "Admin" });
        }

        [AdminAuthorize]
        public ActionResult HomeBlock1Edit()
        {
            HomeBloks1 m = HomeBloks1.GetData();

            return View(m);
        }

        [AdminAuthorize]
        public ActionResult HomeBlock1EditSubmit(HomeBloks1 m)
        {
            XMLHelper.SerializaXML<HomeBloks1>(XMLPath.XMLPath_HomeBlock1, m);
            base.SuccessNotification("Submit successed!");
            return RedirectToAction("HomeBlock1Edit", "HomeAdmin", new { Area = "Admin" });
        }
    }
}
