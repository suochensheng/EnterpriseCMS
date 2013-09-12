using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using ApplicationUtility;

namespace Cargo.App_DataClass
{
    [XmlRoot("TransportLines")]
    public class TransportLines
    {
        public TransportLines()
        {
            Lines = new List<TransportLineItem>();
        }

        public static TransportLines GetData()
        {
            TransportLines m = XMLHelper.DeserializeXML<TransportLines>(XMLPath.XMLPath_TransportLines);
            if (m == null)
            {
                m = new TransportLines();
                m.Lines.Add(new TransportLineItem {
                    LineText = "天津《===》上海、乌鲁木齐、兰州、成都及周边大庆；"
                });
                m.Lines.Add(new TransportLineItem
                {
                    LineText = "天津《===》山东：烟台、威海、青岛、胶州、济南、文登、荣城及周边地区；"
                });
                m.Lines.Add(new TransportLineItem
                {
                    LineText = "天津《===》浙江：杭州、宁波、义乌、衢州、嘉兴、绍兴、温州、金华、丽水及周边地区；"
                });
                m.Lines.Add(new TransportLineItem
                {
                    LineText = "天津《===》山西：长治、太原、大同、阳泉及周边地区；"
                });
                m.Lines.Add(new TransportLineItem
                {
                    LineText = "天津《===》江苏：常州、无锡、苏州、徐州、连云港、扬州、南京及周边地区；"
                });
                m.Lines.Add(new TransportLineItem
                {
                    LineText = "天津《===》河南：信阳、许昌、安阳、开封、商丘、郑州、洛阳、焦作及周边地区；"
                });
                m.Lines.Add(new TransportLineItem
                {
                    LineText = "天津《===》广东：佛山、广州、深圳、东莞及周边地区；"
                });
                m.Lines.Add(new TransportLineItem
                {
                    LineText = "天津《===》辽宁：抚顺、辽阳、鞍山、丹东、营口、盘锦、锦州、葫芦岛、沈阳、大连、铁岭及周边地区；"
                });
                m.Lines.Add(new TransportLineItem
                {
                    LineText = "天津《===》吉林：吉林、长春、四平、通化、河口及周边地区；"
                });
                m.Lines.Add(new TransportLineItem
                {
                    LineText = "天津《===》黑龙江：哈尔滨、大庆、齐齐哈尔、牡丹江、鸡西、黑河、及周边地区；"
                });
                XMLHelper.SerializaXML<TransportLines>(XMLPath.XMLPath_TransportLines, m);
            }
            return m;
        }

        [XmlArrayItem(Type = typeof(TransportLineItem), ElementName = "Lines")]
        public List<TransportLineItem> Lines { get; set; }
    }

    [XmlRoot("TransportLines")]
    public class TransportLineItem
    {
        [XmlElement(ElementName = "LineText")]
        public string LineText { get; set; }
    }
}