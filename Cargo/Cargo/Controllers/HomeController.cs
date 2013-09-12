using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Linq;
using ApplicationUtility;
using Cargo.Models;
using Cargo.App_DataClass;


namespace Cargo.Controllers
{
    public class HomeController : Controller
    {
        private readonly string CityXMLPath= System.AppDomain.CurrentDomain.BaseDirectory + @"App_Data/ChinaCityId.xml";
        //private readonly string MenuXMLPath = System.AppDomain.CurrentDomain.BaseDirectory + @"App_Data/Menu.xml";

        public ActionResult Weather(string cityId = "101010100")
        {
            HttpHelper htmlH = new HttpHelper();
            WebResponse r = htmlH.doGet("http://m.weather.com.cn/data/" + cityId + ".html");
            //中国气象总局的天气接口
            //http://61.4.185.48:81/g/  根据ip获取本地ID 天气预报网
            string s = htmlH.ResponseToString(r);
            if (string.IsNullOrEmpty(s))
            {
                return PartialView("_404NotFound");
            }
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            Weather _Weather = jsonSerializer.Deserialize<Weather>(s);
            return PartialView("_Weather", _Weather);
        }   

        public ActionResult GetWeather(string cityName)
        {
            if (string.IsNullOrEmpty(cityName))
            {
                return RedirectToAction("Weather");
            }

            string cityId = "101010100";
            XDocument xdoc = XDocument.Load(CityXMLPath);


            IList<tempt> tProvince = (from p in xdoc.Descendants("Province")
                                      select new tempt
                                      {
                                          Name = p.Attribute("Name"),
                                          ID = p.Attribute("ID"),
                                      }).ToList();

            tempt tr = tProvince.FirstOrDefault(e => e.Name.Value.Contains(cityName));
            if (tr == null)
            {
                IList<tempt> tCity = (from p in xdoc.Descendants("City")
                                      select new tempt
                                      {
                                          Name = p.Attribute("Name"),
                                          ID = p.Attribute("ID"),
                                      }).ToList();
                tr = tCity.FirstOrDefault(e => e.Name.Value.Contains(cityName));
            }
            if (tr != null)
            {
                cityId = tr.ID.Value;
            }
            return Weather(cityId);
        }

        public class tempt
        {
            public XAttribute ID { get; set; }
            public XAttribute Name { get; set; }
        }

        public ActionResult RenderHomeImageSlider()
        {
            HomeImageSlider m = HomeImageSlider.GetData();
            return PartialView("_HomeImageSlider", m);
        }
        public ActionResult RenderHomeBlock2()
        {
            HomeBloks2 m = HomeBloks2.GetData();
            return PartialView("_HomeBlock2", m);
        }
        public ActionResult RenderHomeBlock1()
        {
            HomeBloks1 m = HomeBloks1.GetData();
            return PartialView("_HomeBlock1", m);
        }
        public ActionResult Footer()
        {
            ContactInfo m = ContactInfo.GetData();
            return PartialView("_Footer", m);
        }
        public ActionResult QQChat()
        {
            ContactInfo m = ContactInfo.GetData();
            return PartialView("_QQChat", m);
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";
            
            return View();
        }

        public ActionResult Contact()
        {
            ContactInfo m = ContactInfo.GetData();
            return View(m);
        }

        public ActionResult GoogleMap()
        {
            return View("GoogleMap");
        }
        public ActionResult BaiduMap()
        {
            return View("BaiduMap");
        }
    }
}
