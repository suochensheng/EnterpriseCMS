using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Web.Script.Serialization;
using ApplicationUtility;

namespace Cargo.App_DataClass
{
    [XmlRoot("HomeImageSlider")]
    public class HomeImageSlider
    {
        public HomeImageSlider()
        {
            Images = new List<HomeImageSliderItem>();
        }

        public static HomeImageSlider GetData()
        {
           HomeImageSlider m= XMLHelper.DeserializeXML<HomeImageSlider>(XMLPath.XMLPath_HomeImageSlider);
           if (m == null)
           {
               m = new HomeImageSlider();
               m.Images.Add(new HomeImageSliderItem {
                   Description = "我们提供优质的服务",
                   Id = "wows1_1",
                   Title="团队",
                   TooltipsUrlContent = "~/Content/wowslider/data1/tooltips/1.jpg",
                   UrlContent = "~/Content/wowslider/data1/images/1.jpg",
               });
               m.Images.Add(new HomeImageSliderItem
               {
                   Description = "强大 稳定",
                   Id = "wows1_2",
                   Title = "运力",
                   TooltipsUrlContent = "~/Content/wowslider/data1/tooltips/2.jpg",
                   UrlContent = "~/Content/wowslider/data1/images/2.jpg",
               });
               m.Images.Add(new HomeImageSliderItem
               {
                   Description = "我们拥有专业的技术团队",
                   Id = "wows1_3",
                   Title = "专业",
                   TooltipsUrlContent = "~/Content/wowslider/data1/tooltips/3.jpg",
                   UrlContent = "~/Content/wowslider/data1/images/3.jpg",
               });
               m.Images.Add(new HomeImageSliderItem
               {
                   Description = "description 4",
                   Id = "wows1_4",
                   Title = "4",
                   TooltipsUrlContent = "~/Content/wowslider/data1/tooltips/4.jpg",
                   UrlContent = "~/Content/wowslider/data1/images/4.jpg",
               });
               m.Images.Add(new HomeImageSliderItem
               {
                   Description = "description 5",
                   Id = "wows1_5",
                   Title = "5",
                   TooltipsUrlContent = "~/Content/wowslider/data1/tooltips/5.jpg",
                   UrlContent = "~/Content/wowslider/data1/images/5.jpg",
               });
               XMLHelper.SerializaXML<HomeImageSlider>(XMLPath.XMLPath_HomeImageSlider, m);
           }
           return m;
        }

        [XmlArrayItem(Type = typeof(HomeImageSliderItem), ElementName = "Images")]
        public List<HomeImageSliderItem> Images { get; set; }

    }

    [XmlRoot("HomeImageSlider")]
    public class HomeImageSliderItem
    {
        [XmlAttribute(AttributeName = "Id")]
        public string Id { get; set; }

        [XmlAttribute(AttributeName = "UrlContent")]
        public string UrlContent { get; set; }

        [XmlAttribute(AttributeName = "TooltipsUrlContent")]
        public string TooltipsUrlContent { get; set; }

        [XmlAttribute(AttributeName = "Title")]
        public string Title { get; set; }

        [XmlAttribute(AttributeName = "Alt")]
        public string Alt { get { return Title; } }

        [XmlElement(ElementName = "Description")]
        public string Description { get; set; }
    }
   
}