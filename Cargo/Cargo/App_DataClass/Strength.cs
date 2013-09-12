using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using ApplicationUtility;

namespace Cargo.App_DataClass
{
    [XmlRoot("Strengths")]
    public class Strength
    {
        public Strength()
        {
           // Lines = new List<TransportLineItem>();
        }

        public static Strength GetData()
        {
            Strength m = XMLHelper.DeserializeXML<Strength>(XMLPath.XMLPath_Strength);
            if (m == null)
            {
                m = new Strength();

                m.Description = "主要承运各类大型、特种物件，以及承担工业搬场业务，拥有承运单件重量1800吨以内各载重吨级的大件运输平板车组和各种大吨位起重吊机，适应各种大型设备和物资的运输、吊装和就位要求。可承接超长、超宽 、超重,、超大型设备和机械的运输业务。以优惠的价格、优质的服务为客户服务，为厂方为运输单位牵线搭桥 ；以优质的服务谋求企业的发展； 以合理的价格应对市场竞争，是本企业发展之道。 ";
                
                m.BlockImage_1 = "~/images/strength/block1.jpg";
                m.BlockTime_1 = string.Format("{0:F}", DateTime.Now);
                m.BlockTitle_1 = "大货件 集装箱";
                m.BlockText_1 = "我们在这里进行安全高速高效的集装箱运输";

                m.BlockImage_2 = "~/images/strength/block2.jpg";
                m.BlockTime_2 = string.Format("{0:F}", DateTime.Now);
                m.BlockTitle_2 = "公路建设项目";
                m.BlockText_2 = "与XX集团共同完成xx路段 土方等各种材料运输项目";

                m.BlockImage_3 = "~/images/strength/block3.jpg";
                m.BlockTime_3 = string.Format("{0:F}", DateTime.Now);
                m.BlockTitle_3 = "货柜长途运输";
                m.BlockText_3 = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Nam cursus. Morbi ut mi. Nullam enim leo, egestas id, condimentum at, laoreet mattis, massa. Sed eleifend nonummy diam. Praesent mauris ante, elementum et, bibendum at, posuere sit amet, nibh. Duis tincidunt... ";

                m.BlockImage_4 = "~/images/strength/block4.jpg";
                m.BlockTime_4 = string.Format("{0:F}", DateTime.Now);
                m.BlockTitle_4 = "The next-gen MacBook Pro with Retina Display Review";
                m.BlockText_4 = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Nam cursus. Morbi ut mi. Nullam enim leo, egestas id, condimentum at, laoreet mattis, massa. Sed eleifend nonummy diam. Praesent mauris ante, elementum et, bibendum at, posuere sit amet, nibh. Duis tincidunt...";

                m.BlockImage_5 = "~/images/strength/block5.jpg";
                m.BlockTime_5 = string.Format("{0:F}", DateTime.Now);
                m.BlockTitle_5 = "Google Nexus 7 and Android 4.1 &nbsp; Mini Review";
                m.BlockText_5 = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Nam cursus. Morbi ut mi. Nullam enim leo, egestas id, condimentum at, laoreet mattis, massa. Sed eleifend nonummy diam. Praesent mauris ante, elementum et, bibendum at, posuere sit amet, nibh. Duis tincidunt... ";

                m.BlockImage_6 = "~/images/strength/block6.jpg";
                m.BlockTime_6 = string.Format("{0:F}", DateTime.Now);
                m.BlockTitle_6 = "HTC One X great review from anandtech";
                m.BlockText_6 = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Nam cursus. Morbi ut mi. Nullam enim leo, egestas id, condimentum at, laoreet mattis, massa. Sed eleifend nonummy diam. Praesent mauris ante, elementum et, bibendum at, posuere sit amet, nibh. Duis tincidunt lectus quis dui viverra vestibulum. Suspendisse vulputate aliquam dui. Nulla elementum dui ut augue. Aliquam vehicula mi at mauris. Maecenas placerat, nisl at consequat rhoncus, sem nunc gravida justo, quis eleifend arcu velit quis lacus. Morbi magna magna, tincidunt a,... ";

                XMLHelper.SerializaXML<Strength>(XMLPath.XMLPath_Strength, m);
            }
            return m;
        }

        [XmlElement(ElementName = "Description")]
        public string Description { get; set; }

        [XmlElement(ElementName = "BlockImage_1")]
        public string BlockImage_1 { get; set; }
        [XmlElement(ElementName = "BlockTime_1")]
        public string BlockTime_1 { get; set; }
        [XmlElement(ElementName = "BlockTitle_1")]
        public string BlockTitle_1 { get; set; }
        [XmlElement(ElementName = "BlockText_1")]
        public string BlockText_1 { get; set; }

        [XmlElement(ElementName = "BlockImage_2")]
        public string BlockImage_2 { get; set; }
        [XmlElement(ElementName = "BlockTime_2")]
        public string BlockTime_2 { get; set; }
        [XmlElement(ElementName = "BlockTitle_2")]
        public string BlockTitle_2 { get; set; }
        [XmlElement(ElementName = "BlockText_2")]
        public string BlockText_2 { get; set; }

        [XmlElement(ElementName = "BlockImage_3")]
        public string BlockImage_3 { get; set; }
        [XmlElement(ElementName = "BlockTime_3")]
        public string BlockTime_3 { get; set; }
        [XmlElement(ElementName = "BlockTitle_3")]
        public string BlockTitle_3 { get; set; }
        [XmlElement(ElementName = "BlockText_3")]
        public string BlockText_3 { get; set; }

        [XmlElement(ElementName = "BlockImage_4")]
        public string BlockImage_4 { get; set; }
        [XmlElement(ElementName = "BlockTime_4")]
        public string BlockTime_4 { get; set; }
        [XmlElement(ElementName = "BlockTitle_4")]
        public string BlockTitle_4 { get; set; }
        [XmlElement(ElementName = "BlockText_4")]
        public string BlockText_4 { get; set; }

        [XmlElement(ElementName = "BlockImage_5")]
        public string BlockImage_5 { get; set; }
        [XmlElement(ElementName = "BlockTime_5")]
        public string BlockTime_5 { get; set; }
        [XmlElement(ElementName = "BlockTitle_5")]
        public string BlockTitle_5 { get; set; }
        [XmlElement(ElementName = "BlockText_5")]
        public string BlockText_5 { get; set; }

        [XmlElement(ElementName = "BlockImage_6")]
        public string BlockImage_6 { get; set; }
        [XmlElement(ElementName = "BlockTime_6")]
        public string BlockTime_6 { get; set; }
        [XmlElement(ElementName = "BlockTitle_6")]
        public string BlockTitle_6 { get; set; }
        [XmlElement(ElementName = "BlockText_6")]
        public string BlockText_6 { get; set; }
    }
}