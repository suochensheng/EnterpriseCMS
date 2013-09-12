using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using ApplicationUtility;

namespace Cargo.App_DataClass
{
    [XmlRoot("Contact")]
    public class ContactInfo
    {
        public static ContactInfo GetData()
        {
            ContactInfo m = XMLHelper.DeserializeXML<ContactInfo>(XMLPath.XMLPath_Contact);
            if (m == null)
            {
                m = new ContactInfo();
                m.qq1 = "1234567";
                m.qq2 = "1234567";
                m.CompanyAddress = "天津市塘沽区尚海园1-1601";
                m.CompanyName = "天津博贸国际";
                m.CompanyPhone = "022-59847196";
                m.CompanyEmail = "suochensheng@163.com";
                XMLHelper.SerializaXML<ContactInfo>(XMLPath.XMLPath_Contact, m);
            }
            return m;
        }

        [XmlAttribute(AttributeName = "qq1")]
        public string qq1 { get; set; }

        [XmlAttribute(AttributeName = "qq2")]
        public string qq2 { get; set; }

        [XmlElement(ElementName = "CompanyEmail")]
        public string CompanyEmail { get; set; }

        [XmlElement(ElementName = "CompanyName")]
        public string CompanyName { get; set; }

        [XmlElement(ElementName = "CompanyPhone")]
        public string CompanyPhone { get; set; }

        [XmlElement(ElementName = "CompanyAddress")]
        public string CompanyAddress { get; set; }


    }
}