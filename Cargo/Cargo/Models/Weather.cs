using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Cargo.Models
{
    [DataContract(Namespace = "Weather")]
    public class Weather
    {
        public Weatherinfo Weatherinfo { get; set; }


    }
    [DataContract(Namespace = "Weather")]
    public class Weatherinfo
    {

        public string GetImageUrl(string image)
        {
            if (string.IsNullOrWhiteSpace(image))
                return "";
            return string.Format("http://m.weather.com.cn/img/b{0}.gif", image);
        }

        [DataMember]
        public string city { get; set; }

        [DataMember]
        public string city_en { get; set; }

        [DataMember]
        public string date_y { get; set; }

        [DataMember]
        public string week { get; set; }

        [DataMember]
        public string fchh { get; set; }

        [DataMember]
        public string cityid { get; set; }

        [DataMember]
        public string temp1 { get; set; }

        [DataMember]
        public string temp2 { get; set; }

        [DataMember]
        public string temp3 { get; set; }

        [DataMember]
        public string weather1 { get; set; }

        [DataMember]
        public string weather2 { get; set; }

        [DataMember]
        public string weather3 { get; set; }

        [IgnoreDataMember]
        private string _img1;
        [DataMember]
        public string img1 { get { return GetImageUrl(_img1); } set { _img1 = value; } }

        [IgnoreDataMember]
        private string _img2;
        [DataMember]
        public string img2 { get { return GetImageUrl(_img2); } set { _img2 = value; } }

        [IgnoreDataMember]
        private string _img3;
        [DataMember]
        public string img3 { get { return GetImageUrl(_img3); } set { _img3 = value; } }

        [IgnoreDataMember]
        private string _img4;
        [DataMember]
        public string img4 { get { return GetImageUrl(_img4); } set { _img4 = value; } }

        [IgnoreDataMember]
        private string _img5;
        [DataMember]
        public string img5 { get { return GetImageUrl(_img5); } set { _img5 = value; } }

        [IgnoreDataMember]
        private string _img6;
        [DataMember]
        public string img6 { get { return GetImageUrl(_img6); } set { _img6 = value; } }

        [DataMember]
        public string img_title1 { get; set; }

        [DataMember]
        public string img_title2 { get; set; }

        [DataMember]
        public string img_title3 { get; set; }

        [DataMember]
        public string img_title4 { get; set; }

        [DataMember]
        public string img_title5 { get; set; }

        [DataMember]
        public string img_title6 { get; set; }

        [DataMember]
        public string wind1 { get; set; }

        [DataMember]
        public string wind2 { get; set; }

        [DataMember]
        public string wind3 { get; set; }


        [DataMember]
        public string index { get; set; }

        [DataMember]
        public string index_d { get; set; }

        [DataMember]
        public string index_xc { get; set; }
    }
}