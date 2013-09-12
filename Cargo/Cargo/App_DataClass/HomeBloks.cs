using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using ApplicationUtility;

namespace Cargo.App_DataClass
{
    [XmlRoot("HomeBlok2")]
    public class HomeBloks2
    {

        public static HomeBloks2 GetData()
        {
            HomeBloks2 m = XMLHelper.DeserializeXML<HomeBloks2>(XMLPath.XMLPath_HomeBlock2);
            if (m == null)
            {
                m = new HomeBloks2();

                m.NewsDescription = " 上半年天津保税区经济总量稳定增长 同比增加18.3%;到2016年天津港口货物"+
                "吞吐量将达6亿吨. 60家企业落户天津滨海新区中心渔港聚集冷链物流产业."+
                "天津航空暂停呼和出港E145机型货邮运输业务.";
                m.NewsTitle = "天津物流新闻";
                m.TeamDescription = "我们提供优秀的团队服务,对每一个客户都认真接待,我们有强大的技术团队也有强大的智慧团！我们发展核心竞争力,扩大运输途径 方法 方式,现在化管理团队 科技发展企业,正规高效,达到资源扩大并有效利用！";
                m.TeamTitle = "强力的团队";
                m.WorkDescription = "求实,高效,安全,严谨 我们提供良好的工作环境和平台,每一次工作我们都全力以赴认真仔细去完成！";
                m.WorkTitle = "做最好的工作";

                XMLHelper.SerializaXML<HomeBloks2>(XMLPath.XMLPath_HomeBlock2, m);
            }
            return m;
        }


        [XmlAttribute(AttributeName = "NewsTitle")]
        public string NewsTitle { get; set; }

        [XmlElement(ElementName = "NewsDescription")]
        public string NewsDescription { get; set; }

        [XmlAttribute(AttributeName = "WorkTitle")]
        public string WorkTitle { get; set; }

        [XmlElement(ElementName = "WorkDescription")]
        public string WorkDescription { get; set; }

        [XmlAttribute(AttributeName = "TeamTitle")]
        public string TeamTitle { get; set; }

        [XmlElement(ElementName = "TeamDescription")]
        public string TeamDescription { get; set; }
    }



    [XmlRoot("HomeBlok1")]
    public class HomeBloks1
    {
        public HomeBloks1()
        {
            Bloks = new List<HomeBloks1Item>();
        }
        public static HomeBloks1 GetData()
        {
            HomeBloks1 m = XMLHelper.DeserializeXML<HomeBloks1>(XMLPath.XMLPath_HomeBlock1);
            if (m == null)
            {
                m = new HomeBloks1();

                m.Bloks.Add(new HomeBloks1Item {
                    Title = "大件运输",
                    ShortDesc = "京津冀 区域",
                Description="天津市西青区从新配货站主要承运各类大型、特种物件，以及承担工业搬场业务，"+
                       "拥有承运单件重量1800吨以内各载重吨级的大件运输平板车组和各种大吨位起重吊机，"+
                       "适应各种大型设备和物资的运输、吊装和就位要求。可承接超长、超宽 、超重,、超大型设备和机械的运输业务。"+
                       "以优惠的价格、优质的服务为客户服务，为厂方为运输单位牵线搭桥 ；"+
                       "以优质的服务谋求企业的发展； 以合理的价格应对市场竞争，是本企业发展之道。 ",
                });

                m.Bloks.Add(new HomeBloks1Item
                {
                    Title = "长途搬家",
                    ShortDesc = "经营范围",
                    Description = " 宾馆、商厦、大卖场和个人的中小件货物搬运 "+
                        "· 驻沪使领馆、在沪外国家庭的涉外特种搬场 "+
                        "· 居民搬场、小件快运、大都市配送 "+
                        "· 商务楼、企事业单位的大规模搬迁  ",
                });

                XMLHelper.SerializaXML<HomeBloks1>(XMLPath.XMLPath_HomeBlock1, m);
            }
            return m;
        }

        [XmlArrayItem(Type = typeof(HomeBloks1Item), ElementName = "Bloks")]
        public List<HomeBloks1Item> Bloks { get; set; }
    }

    [XmlRoot("HomeBlok1")]
    public class HomeBloks1Item
    {
        [XmlAttribute(AttributeName = "Title")]
        public string Title { get; set; }

        [XmlElement(ElementName = "ShortDesc")]
        public string ShortDesc { get; set; }

        [XmlElement(ElementName = "Description")]
        public string Description { get; set; }
    }
}