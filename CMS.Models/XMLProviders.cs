using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace CMS.Models
{
    public class XmlProviders
    {
        #region XmlStringConverters -commented by RK
        public string GetXmlObjectString<T>(T Details)
        {
            string xml = "";
            using (StringWriter sw = new StringWriter())
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                xs.Serialize(sw, Details);
                xml = sw.ToString().Replace("utf-16", "utf-8");
            }
            string ReplaceXML = xml.Replace("<?xml version=\"1.0\" encoding=\"utf-8\"?>", " ").Trim();
            string ReplaceXmlTable = ReplaceXML.Replace("xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">", ">").Trim();
            xml = ReplaceXmlTable.Replace("xsi:nil=\"true\"", "").Replace("xsi:type=\"xsd:boolean\"", "").Replace("xsi:type=\"xsd:string\"", "").Trim();
            return xml;
        }
        public string GetXmlArrayString<T>(List<T> listDetails)
        {
            string xml = "";
            using (StringWriter sw = new StringWriter())
            {
                XmlSerializer xs = new XmlSerializer(typeof(List<T>));
                xs.Serialize(sw, listDetails);
                xml = sw.ToString().Replace("utf-16", "utf-8");
            }
            string ReplaceXML = xml.Replace("<?xml version=\"1.0\" encoding=\"utf-8\"?>", " ").Trim();
            string ReplaceXmlTable = ReplaceXML.Replace("xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"", "").Trim();
            xml = ReplaceXmlTable.Replace("xsi:nil=\"true\"", "").Replace("xsi:type=\"xsd:boolean\"", "").Replace("xsi:type=\"xsd:string\"", "");
            return xml;
        }
        public string GetXmlArrayString2()
        {
            string xml = "";
            return xml;
        }
        public string GetXmlArrayString1<T>(List<T> listDetails)
        {
            string xml = "";
            using (StringWriter sw = new StringWriter())
            {
                XmlSerializer xs = new XmlSerializer(typeof(List<T>), new XmlRootAttribute("NewDataSet"));
                xs.Serialize(sw, listDetails);
                xml = sw.ToString().Replace("utf-16", "utf-8");
                xml = sw.ToString().Replace("&lt;", "<").Replace("&gt;", ">");
            }
            string ReplaceXML = xml.Replace("<?xml version=\"1.0\" encoding=\"utf-8\"?>", " ").Trim();
            string ReplaceXmlTable = ReplaceXML.Replace("xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"", "").Trim();
            xml = ReplaceXmlTable.Replace("xsi:nil=\"true\"", "").Replace("xsi:type=\"xsd:boolean\"", "").Replace("xsi:type=\"xsd:string\"", "").Trim();
            string qxml = xml.Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>", "").Trim();
            return qxml;
        }
        #endregion


        #region Comented by Arvind
        public string GetXmlObjectStringClient<T>(T Details)
        {
            string xml = "";
            using (StringWriter sw = new StringWriter())
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                xs.Serialize(sw, Details);
                xml = sw.ToString().Replace("utf-16", "utf-8");
                xml = sw.ToString().Replace("&lt;", "<").Replace("&gt;", ">");
            }
            string ReplaceXML = xml.Replace("<?xml version=\"1.0\" encoding=\"utf-8\"?>", " ").Trim();
            string ReplaceXmlTable = ReplaceXML.Replace("xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">", ">").Trim();
            xml = ReplaceXmlTable.Replace("xsi:nil=\"true\"", "").Replace("xsi:type=\"xsd:boolean\"", "").Replace("xsi:type=\"xsd:string\"", "").Trim();
            return xml;
        }
        #endregion
    }
}
